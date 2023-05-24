using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class CompanyBases
    {
        [Key]
        public int CompanyBaseId { get; set; }
        public int CountryId { get; set; }
        [MaxLength(50)]
        public string CompanyBaseName { get; set; }
        [MaxLength(200)]
        public string Information { get; set; }
        [JsonIgnore]
        [ForeignKey("CountryId")]
        public virtual Countries Countries { get; set; }
    }
}
