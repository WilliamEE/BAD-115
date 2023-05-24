using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class PagePhrases
    {
        [Key]
        public int PageParagraphId { get; set; }
        public int PageInformationId { get; set; }
        public string PagePhraseImage { get; set; }
        [MaxLength(500)]
        public string Author { get; set; }
        [MaxLength(500)]
        public string AuthorEn { get; set; }
        [MaxLength(500)]
        public string Information { get; set; }
        [MaxLength(500)]
        public string InformationEn { get; set; }
        public int Position { get; set; }
        [ForeignKey("PageInformationId")]
        public PageInformations PageInformations { get; set; }
    }
}
