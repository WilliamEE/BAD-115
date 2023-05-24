using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class UserItems
    {
        [Key]
        public int UserItemsId { get; set; }
        [JsonIgnore]
        [ForeignKey("UserId")]
        public virtual Users Users { get; set; }
        [JsonIgnore]
        [ForeignKey("ItemId")]
        public virtual Items Items { get; set; }
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public bool? See { get; set; }
        public bool? Add { get; set; }
        public bool? Edit { get; set; }
        public bool? Delete { get; set; }
    }
}
