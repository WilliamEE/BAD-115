using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class Rols
    {
        [Key]
        public int RolId { get; set; }
        [MaxLength(50)]
        public string RolName { get; set; }
        [JsonIgnore]
        public virtual ICollection<RolsItems> RolsItems { get; set; }
        public bool IsAdmin { get; set; }
    }
}
