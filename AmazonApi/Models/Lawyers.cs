using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class Lawyers
    {
        [Key]
        public int LawyerId { get; set; }
        public int OfficeId { get; set; }
        public int LawyerCategoryId { get; set; }
        [MaxLength(50)]
        public string FirtsName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(15)]
        public string Telephone { get; set; }
        public string SocialProfessionalNetwork { get; set; }
        public string LawyerImage { get; set; }
        [MaxLength(2000)]
        public string Information { get; set; }
        [MaxLength(2000)]
        public string InformationEn { get; set; }
        public bool Visible { get; set; }
        public string VcardUrl { get; set; }
        public string VcardUrlMobile { get; set; }
        public string VcardImage { get; set; }
        [ForeignKey("OfficeId")]
        public virtual Offices Offices { get; set; }
        [ForeignKey("LawyerCategoryId")]
        public virtual LawyerCategories LawyerCategories { get; set; }
        public virtual ICollection<LawyerAcademicInfos> LawyerAcademicInfos { get; set; }
        public virtual ICollection<LawyerClientFeedbacks> LawyerClientFeedbacks { get; set; }
        public virtual ICollection<LawyerLanguages> LawyerLanguages { get; set; }
        public virtual ICollection<LawyerMemberships> LawyerMemberships { get; set; }
        public virtual ICollection<LawyerPracticeAreas> LawyerPracticeAreas { get; set; }
        public virtual ICollection<LawyerRecognitions> LawyerRecognitions { get; set; }
        public virtual ICollection<LawyerRecognitionImages> LawyerRecognitionImages { get; set; }
        public virtual ICollection<ArticleAuthors> ArticleAuthors { get; set; }
    }
}
