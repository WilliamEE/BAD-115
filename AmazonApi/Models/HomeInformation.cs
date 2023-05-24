using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class HomeInformation
    {
        [Key]
        public int HomeInformationId { get; set; }
        public int PageId { get; set; }
        [MaxLength(200)]
        public string TitleESP { get; set; }
        [MaxLength(200)]
        public string TitleEn { get; set; }
        [MaxLength(500)]
        public string DescriptionESP { get; set; }
        [MaxLength(500)]
        public string DescriptionEn { get; set; }
        [MaxLength(200)]
        public string AboutUsTitle { get; set; }
        [MaxLength(200)]
        public string AboutUsTitleEn { get; set; }
        [MaxLength(1200)]
        public string AboutUsDescription { get; set; }
        [MaxLength(1200)]
        public string AboutUsDescriptionEn { get; set; }
        public string AboutUsImage { get; set; }
        [MaxLength(200)]
        public string RegionTitle { get; set; }
        [MaxLength(200)]
        public string RegionTitleEn { get; set; }
        [MaxLength(500)]
        public string RegionDescription { get; set; }
        [MaxLength(500)]
        public string RegionDescriptionEn { get; set; }
        [MaxLength(200)]
        public string SustainabilityTitle { get; set; }
        [MaxLength(200)]
        public string SustainabilityTitleEn { get; set; }
        [MaxLength(500)]
        public string SustainabilityDescription { get; set; }
        [MaxLength(500)]
        public string SustainabilityDescriptionEn { get; set; }
        public string SustainabilityImage { get; set; }
        public string CounterImage { get; set; }
        [MaxLength(200)]
        public string NewsTitle { get; set; }
        [MaxLength(200)]
        public string NewsTitleEn { get; set; }
        [MaxLength(500)]
        public string NewsDescription { get; set; }
        [MaxLength(500)]
        public string NewsDescriptionEn { get; set; }
        [ForeignKey("PageId")]
        public virtual Pages Pages { get; set; }
        public virtual ICollection<HomeInformationCounters> HomeInformationCounters { get; set; }
    }
}
