using MarketingWebApi.Data;
using MarketingWebApi.Utilities;
using MarketingWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketingWebApi.Models.Utilities;

namespace MarketingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersAuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IUserService _userService;
        public UsersAuthController(IUserService userService, ApplicationDbContext context)
        {
            _userService = userService;
            _context = context;
        }

        [HttpPost]
        public ActionResult<UserResponse> SingIn(AuthRequest authRequest)
        {
            var userresponse = _userService.Auth(authRequest, _context);

            if (userresponse == null)
            {
                return NoContent();
            }

            return Ok(userresponse);
        }
    }
}
