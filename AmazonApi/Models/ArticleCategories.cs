using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class ArticleCategories
    {
        [Key]
        public int ArticleCategoryId { get; set; }
        [MaxLength(50)]
        public string CategoryName { get; set; }
        [MaxLength(50)]
        public string CategoryNameEn { get; set; }
        public int Visible { get; set; }
    }
}
