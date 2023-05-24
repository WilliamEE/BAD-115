using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class Languages
    {
        [Key]
        public int LanguageId { get; set; }
        [MaxLength(50)]
        public string LanguageName { get; set; }
        [MaxLength(50)]
        public string LanguageNameEn { get; set; }
        [MaxLength(2)]
        public string Abbreviation { get; set; }
        public bool Visible { get; set; }
    }
}
