using AmazonApi.Models.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using AmazonApi.Models;
using MarketingWebApi.Models;

namespace AmazonApi.Utilities
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
      public   UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public UserResponse Auth(AuthRequest model, BD_AmazonContext context)
        {
            UserResponse userResponse = new();
            using (var db = context)
            {
                //Encriptar la clave para validar con el sistema.
                var usuario = db.Users
                    .Include(t => t.Rols)
                    .Where(x => x.UserUser == model.User && x.UserPassword == model.Password && x.IsActive == true)
                    .AsNoTracking()
                    .IgnoreAutoIncludes()
                    .FirstOrDefault();

                if (usuario == null) return null;

                userResponse.UserEmail = usuario.UserEmail;
                userResponse.UserName = usuario.UserName;
                userResponse.UserId = usuario.UserId;
                userResponse.UserUser = usuario.UserUser;
                userResponse.RolId = usuario.RolId;

                //Optener el token con sus datos de expiración.
                var token = GetToken(usuario);
                userResponse.Expires = Convert.ToInt32(token[0]);
                userResponse.ExpirationTime = Convert.ToDateTime(token[1]);
                userResponse.UserToken = token[2].ToString();
            }

            return userResponse;
        }

        private object[] GetToken(Users user)
        {
            //Usamos la libreria para generar tokens que nos provee .net core.
            var tokenHandler = new JwtSecurityTokenHandler();
            //Codificamos la clave secreta de appsetings
            var KeySecret = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("Secret"));

            //Optenemos el toque indicando los Claims y encriptando la información con SHA256 de ASCII.
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                            {
                                new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                                new Claim(ClaimTypes.Email,user.UserEmail)
                            }),
                            Expires  = DateTime.UtcNow.AddHours(24),
                            SigningCredentials = 
                            new SigningCredentials(new SymmetricSecurityKey(KeySecret),SecurityAlgorithms.HmacSha256Signature)

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            object[] Token = new object[] { 24*60, DateTime.Now.AddHours(24),  tokenHandler.WriteToken(token) };

            return Token;

        }
    }
}
