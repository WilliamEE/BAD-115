using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class PageParagraphs
    {
        [Key]
        public int PageParagraphId { get; set; }
        public int PageInformationId { get; set; }
        public string PageParagraphImage { get; set; }
        [MaxLength(200)]
        public string PageParagraphTitle { get; set; }
        [MaxLength(200)]
        public string PageParagraphTitleEn { get; set; }
        [MaxLength(1200)]
        public string FirstParagraph { get; set; }
        [MaxLength(1200)]
        public string FirstParagraphEn { get; set; }
        public string SecondParagraph { get; set; }
        public string SecondParagraphEn { get; set; }
        public int Position { get; set; }
        [ForeignKey("PageInformationId")]
        public PageInformations PageInformations { get; set; }
    }
}
