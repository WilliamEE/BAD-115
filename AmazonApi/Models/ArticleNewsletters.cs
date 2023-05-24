using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class ArticleNewsletters
    {
        [Key]
        public int ArticleNewsletterId { get; set; }
        public int ArticleId { get; set; }
        public int NewsletterId { get; set; }
        [ForeignKey("ArticleId")]
        public virtual Articles Articles { get; set; }
        [ForeignKey("NewsletterId")]
        public virtual Newsletters Newsletters { get; set; }
    }
}
