using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class LawyerClientFeedbacks
    {
        [Key]
        public int LawyerClientFeedbackId { get; set; }
        public int LawyerId { get; set; }
        [MaxLength(500)]
        public string Information { get; set; }
        [MaxLength(500)]
        public string InformationEn { get; set; }
        public bool Visible { get; set; }
        [ForeignKey("LawyerId")]
        public virtual Lawyers Lawyers { get; set; }
    }
}
