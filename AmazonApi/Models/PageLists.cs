using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class PageLists
    {
        [Key]
        public int PageListId { get; set; }
        public int PageInformationId { get; set; }
        [MaxLength(300)]
        public string PageListDescription{ get; set; }
        [MaxLength(300)]
        public string PageListDescriptionEn { get; set; }
        public int Position { get; set; }
        [ForeignKey("PageInformationId")]
        public PageInformations PageInformations { get; set; }
    }
}
