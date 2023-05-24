using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class Months
    {
        [Key]
        public int MonthId { get; set; }
        public int MonthPosition { get; set; }
        [MaxLength(50)]
        public string MonthName { get; set; }
        [MaxLength(50)]
        public string MonthNameEn { get; set; }
    }
}
