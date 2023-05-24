using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class Pages
    {
        [Key]
        public int PageId { get; set; }
        [MaxLength(50)]
        public string PageName { get; set; }
        public int Code { get; set; }
        public int ParagraphQuantity { get; set; }
        public int PhraseQuantity { get; set; }
        public virtual ICollection<PageInformations> PageInformations { get; set; }
    }
}
