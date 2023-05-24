using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AmazonApi.Utilities
{
    public static class EncryptPassword
    {
        private static readonly string Key = "Marketingglobal$$2023##";
        public static string GenerateSHA256(this string value)
        {
            SHA256 sHA256 = SHA256.Create();
            var encoding = new ASCIIEncoding();
            StringBuilder stringBuilder = new();
            byte[] stream = sHA256.ComputeHash(encoding.GetBytes(value+Key));
            for (int i = 0; i < stream.Length; i++) stringBuilder.AppendFormat("{0:x2}",stream[i]);
            
            return stringBuilder.ToString();
        }
    }
}
