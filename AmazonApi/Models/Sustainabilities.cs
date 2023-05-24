using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class Sustainabilities
    {
        [Key]
        public int SustainabilityId { get; set; }
        [MaxLength(100)]
        public string SustainabilityName { get; set; }
        public string SustainabilityImage { get; set; }
    }
}
