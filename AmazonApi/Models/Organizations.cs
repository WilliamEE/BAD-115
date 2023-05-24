using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class Organizations
    {
        [Key]
        public int OrganizationId { get; set; }
        [MaxLength(50)]
        public string OrganizationName { get; set; }
        [MaxLength(50)]
        public string OrganizationNameEn { get; set; }
        public string OrganizationImage { get; set; }
        public bool Visible { get; set; }
        public virtual ICollection<Awards> Awards { get; set; }
    }
}
