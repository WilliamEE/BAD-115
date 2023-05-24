using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class Modules
    {
        [Key]
        public int ModulId { get; set; }
        [MaxLength(50)]
        public string ModulName { get; set; }
        [MaxLength(50)]
        public string Icon { get; set; }
        public virtual ICollection<Items> Items { get; set; }

    }
}
