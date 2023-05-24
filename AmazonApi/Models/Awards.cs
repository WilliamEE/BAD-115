using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class Awards
    {
        [Key]
        public int AwardId { get; set; }
        public int OrganizationId { get; set; }
        [MaxLength(200)]
        public string AwardName { get; set; }
        [MaxLength(200)]
        public string AwardNameEn { get; set; }
        public bool Visible { get; set; }
        public virtual ICollection<AwardYears> AwardYears { get; set; }
        [ForeignKey("OrganizationId")]
        public virtual Organizations Organizations { get; set; }
    }
}
