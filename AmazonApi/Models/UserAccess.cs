using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class UserAccess
    {
        [Key]
        public int UserAccesId { get; set; }
        public int UserId { get; set; }
        public DateTime DateAcces { get; set; }
        public string AccessToken { get; set; }
        public string MachineName { get; set; }
        public string IpAddress { get; set; }
        public string HostName { get; set; }
    }
}
