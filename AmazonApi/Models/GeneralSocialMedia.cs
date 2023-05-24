using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class GeneralSocialMedia
    {
        [Key]
        public int SocialMediaId { get; set; }
        [MaxLength(100)]
        public string SocialMediaName { get; set; }
        [MaxLength(500)]
        public string SocialMediaLink { get; set; }
        [MaxLength(50)]
        public string SocialMediaIcon { get; set; }
        public int SocialMediaPosition { get; set; }
    }
}
