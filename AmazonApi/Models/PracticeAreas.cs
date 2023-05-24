using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class PracticeAreas
    {
        [Key]
        public int PracticeAreaId { get; set; }
        [MaxLength(80)]
        public string PracticeAreaName { get; set; }
        [MaxLength(80)]
        public string PracticeAreaNameEn { get; set; }
        [MaxLength(80)]
        public string ShortPracticeAreaName { get; set; }
        [MaxLength(80)]
        public string ShortPracticeAreaNameEn { get; set; }
        public string PracticeAreaImage { get; set; }
        public bool Visible { get; set; }

        public virtual PageInformations PageInformations { get; set; }
        public virtual LawyerPracticeAreas LawyerPracticeAreas { get; set; }
    }
}
