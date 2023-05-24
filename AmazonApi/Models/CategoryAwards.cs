using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class CategoryAwards
    {
        [Key]
        public int CategoryAwardId { get; set; }
        [MaxLength(50)]
        public string CategoryAwardName { get; set; }
        [MaxLength(50)]
        public string CategoryAwardNameEn { get; set; }
        public int FirstYear { get; set; }
        public int LastYear { get; set; }
    }
}
