using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class UserModuls
    {
        [Key]
        public int RolModulId { get; set; }
        public int ModulId { get; set; }
        public string ModulName { get; set; }
        public string PageName { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
    }
}
