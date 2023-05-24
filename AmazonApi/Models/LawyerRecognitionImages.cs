using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class LawyerRecognitionImages
    {
        [Key]
        public int LawyerRecognitionId { get; set; }
        public int LawyerId { get; set; }
        public int OrganizationId { get; set; }
        public int RecognitionYear { get; set; }
        public string RecognitionImage { get; set; }
        public bool Visible { get; set; }
        [ForeignKey("LawyerId")]
        public virtual Lawyers Lawyers { get; set; }
        [ForeignKey("OrganizationId")]
        public virtual Organizations Organizations  { get; set; }
    }
}
