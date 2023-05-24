using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class LawyerLanguages
    {
        [Key]
        public int LawyerLanguageId { get; set; }
        public int LawyerId { get; set; }
        public int LanguageId { get; set; }
        [ForeignKey("LawyerId")]
        public virtual Lawyers Lawyers { get; set; }
        [ForeignKey("LanguageId")]
        public virtual Languages Languages { get; set; }
    }
}
