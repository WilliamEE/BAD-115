using AmazonApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonApi.Utilities
{
    public class UserResponse
    {
        [Key]
        public int UserId { get; set; }
        public  string UserName{ get; set; }
        public string UserUser { get; set; }
        public string UserEmail { get; set; }
        public string UserToken { get; set; }
        public int OfficeId { get; set; }
        public int RolId { get; set; }
        public int Expires { get; set; }
        public DateTime ExpirationTime { get; set; }
    }
}
