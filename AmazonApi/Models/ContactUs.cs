using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class ContactUs
    {
        [Key]
        public int ContactId { get; set; }
        [MaxLength(100)]
        public string FullName { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(100)]
        public string LawyerEmail { get; set; }
        public int? CountryId { get; set; }
        [MaxLength(500)]
        public string ContactMessage { get; set; }
        [ForeignKey("CountryId")]
        public virtual Countries Countries { get; set; }
    }
}
