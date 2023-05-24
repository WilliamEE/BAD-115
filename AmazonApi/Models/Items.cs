using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class Items
    {
        [Key]
        public int ItemId { get; set; }
        [MaxLength(100)]
        public string ItemName { get; set; }
        [MaxLength(50)]
        public string ItemLink { get; set; }
        public int ModulId { get; set; }
        [ForeignKey("ModulId")]
        public virtual Modules Moduls { get; set; }
        public virtual ICollection<RolsItems> RolsItems { get; set; }
        public virtual ICollection<UserItems> UserItems { get; set; }
    }
}
