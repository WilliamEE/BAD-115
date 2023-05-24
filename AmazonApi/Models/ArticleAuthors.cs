using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class ArticleAuthors
    {
        [Key]
        public int ArticleAuthorId { get; set; }
        public int LawyerId { get; set; }
        public int ArticleId { get; set; }
        [ForeignKey("LawyerId")]
        public virtual Lawyers Lawyers { get; set; }
        [ForeignKey("ArticleId")]
        public virtual Articles Articles { get; set; }
    }
}
