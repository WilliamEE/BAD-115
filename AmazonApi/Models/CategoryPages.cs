using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class CategoryPages
    {
        [Key]
        public int CategoryPageId { get; set; }
        [MaxLength(50)]
        public string CategoryPageName { get; set; }
        public int CategoryPageCode { get; set; }
    }
}
