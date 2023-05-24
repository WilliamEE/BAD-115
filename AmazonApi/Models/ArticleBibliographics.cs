using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class ArticleBibliographics
    {
        [Key]
        public int BibliographicId { get; set; }
        public int ArticleId { get; set; }
        [MaxLength(200)]
        public string ReferenceDescription { get; set; }
        [MaxLength(200)]
        public string ReferenceDescriptionEn { get; set; }
        public string ReferenceUrl { get; set; }
        [ForeignKey("ArticleId")]
        public virtual Articles Articles { get; set; }
    }
}
