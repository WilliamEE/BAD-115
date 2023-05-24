using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class Countries
    {
        [Key]
        public int CountryId { get; set; }
        [MaxLength(50)]
        public string CountryName { get; set; }
         [MaxLength(50)]
        public string CountryNameEn { get; set; }
        [MaxLength(2)]
        public string Abbreviation { get; set; }
        public string CountryImage { get; set; }
        public int FoundationYear { get; set; }
        public int RegionalOrder { get; set; }
        [MaxLength(50)]
        public string CountryEmail { get; set; }
        [MaxLength(20)]
        public string CountryPhoneNumber { get; set; }
        public virtual ICollection<Offices> Offices { get; set; }
    }
}
