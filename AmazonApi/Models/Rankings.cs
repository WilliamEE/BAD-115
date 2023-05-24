using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class Rankings
    {
        [Key]
        public int RankingId { get; set; }
        public int OrganizationId { get; set; }
        [MaxLength(50)]
        public string RankingName { get; set; }
        [MaxLength(50)]
        public string RankingNameEn { get; set; }
        [MaxLength(200)]
        public string RankingDescription { get; set; }
        [MaxLength(200)]
        public string RankingDescriptionEn { get; set; }
        public string RankingImage { get; set; }
        public bool Visible { get; set; }
    }
}
