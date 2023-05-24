using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class RolsItems
    {
        [Key]
        public int RolItemId { get; set; }
        public int RolId { get; set; }
        public int ItemId { get; set; }
        [ForeignKey("RolId")]
        public virtual Rols Rols { get; set; }
        [ForeignKey("ItemId")]
        public virtual Items Items { get; set; }

    }
}
