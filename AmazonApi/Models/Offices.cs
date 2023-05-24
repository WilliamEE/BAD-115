using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class Offices
    {
        [Key]
        [JsonIgnore]
        public int OfficeId { get; set; }
        public int CountryId { get; set; }
        [MaxLength(50)]
        public string OfficeName { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(15)]
        public string Telephone { get; set; }
        [MaxLength(15)]
        public string SecondTelephone { get; set; }
        [MaxLength(500)]
        public string OfficeLocation { get; set; }
        public string GoogleMapsLocation { get; set; }
        public string OfficeMapImage { get; set; }
        [ForeignKey("CountryId")]
        public virtual Countries Countries { get; set; }
    }
}
