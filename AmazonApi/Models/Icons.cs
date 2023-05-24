using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class Icons
    {
        [Key]
        public int IconId { get; set; }
        [MaxLength(50)]
        public string IconName { get; set; }
        [MaxLength(50)]
        public string IconUrl { get; set; }
    }
}
