using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class LawyerCategories
    {
        [Key]
        public int LawyerCategoryId { get; set; }
        [MaxLength(50)]
        public string LawyerCategoryName { get; set; }
        [MaxLength(50)]
        public string LawyerCategoryNameEn { get; set; }
        public int Position { get; set; }
        public bool Visible { get; set; }
    }
}
