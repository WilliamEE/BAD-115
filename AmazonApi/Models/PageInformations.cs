using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class PageInformations
    {
        [Key]
        public int PageInformationId { get; set; }
        [MaxLength(100)]
        public string PageInformationTitle { get; set; }
        [MaxLength(100)]
        public string PageInformationTitleEn { get; set; }
        public string ImageBanner { get; set; }
        [MaxLength(700)]
        public string Information { get; set; }
        [MaxLength(700)]
        public string InformationEn { get; set; }
        public int? PageId { get; set; }

        public int? PracticeAreaId { get; set; }
        

        [ForeignKey("PageId")]
        public virtual Pages Pages { get; set; }
        [ForeignKey("PracticeAreaId")]
        public virtual PracticeAreas PracticeAreas { get; set; }
        public  ICollection<PageParagraphs> PageParagraphs { get; set; }
        public  ICollection<PagePhrases> PagePhrases { get; set; }
        public  ICollection<PageLists> PageLists { get; set; }
    }
}
