using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class Diversities
    {
        [Key]
        public int DiversityId { get; set; }
        [MaxLength(100)]
        public string DiversityName { get; set; }
        [MaxLength(200)]
        public string DiversityDescription { get; set; }
        [MaxLength(200)]
        public string DiversityDescriptionEn { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Percentage { get; set; }
    }
}
