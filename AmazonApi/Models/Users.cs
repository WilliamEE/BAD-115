using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        [MaxLength(100)]
        public string UserName { get; set; }
        [MaxLength(50)]
        public string UserEmail { get; set; }
        public string UserUser { get; set; }
        public string UserPassword { get; set; }
        public int RolId { get; set; }
        [ForeignKey("RolId")]
        public virtual Rols Rols { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserItems> UserItems { get; set; }
        public bool IsActive { get; set; }
    }
}
