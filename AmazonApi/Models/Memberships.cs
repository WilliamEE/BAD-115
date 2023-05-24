using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class Memberships
    {
        [Key]
        public int MembershipId { get; set; }
        [MaxLength(50)]
        public string MembershipName { get; set; }
        [MaxLength(100)]
        public string MembershipDescription { get; set; }
        [MaxLength(100)]
        public string MembershipDescriptionEn { get; set; }
        public string MembershipImage { get; set; }
        public bool Visible { get; set; }
    }
}
