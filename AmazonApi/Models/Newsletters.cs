using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class Newsletters
    {
        [Key]
        public int NewsletterId { get; set; }
        public int MonthId { get; set; }
        public int NewsletterYear { get; set; }
        public bool Visible { get; set; }
        public string NewsletterImage { get; set; }
        public string NewsletterImageEn { get; set; }
        [ForeignKey("MonthId")]
        public virtual Months Months { get; set; }
        public virtual ICollection<ArticleNewsletters> ArticleNewsletters { get; set; }
    }
}
