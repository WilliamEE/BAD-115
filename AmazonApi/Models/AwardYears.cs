using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class AwardYears
    {
        [Key]
        public int AwardYearId { get; set; }
        public int AwardId { get; set; }
        public int AwardYear { get; set; }
        public bool Visible { get; set; }
        [ForeignKey("AwardId")]
        public virtual Awards Awards { get; set; }
    }
}
