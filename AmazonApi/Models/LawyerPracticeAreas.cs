using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class LawyerPracticeAreas
    {
        [Key]
        public int LawyerPracticeAreaId { get; set; }
        public int LawyerId { get; set; }
        public int PracticeAreaId { get; set; }
        [ForeignKey("LawyerId")]
        public virtual Lawyers Lawyers { get; set; }
        [ForeignKey("PracticeAreaId")]
        public virtual PracticeAreas PracticeAreas { get; set; }
    }
}
