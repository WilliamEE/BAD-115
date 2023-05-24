using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class Articles
    {
        [Key]
        public int ArticleId { get; set; }
        public int CountryId { get; set; }
        public int PracticeAreaId { get; set; }
        public int ArticleCategoryId { get; set; }
        [MaxLength(300)]
        public string ArticleTitle { get; set; }
        [MaxLength(300)]
        public string ArticleTitleEn { get; set; }
        public DateTime PublicationDate { get; set; }
        public string VoiceNote { get; set; }
        public string VoiceNoteEn { get; set; }
        public string ArticleImage { get; set; }
        [MaxLength(300)]
        public string Phrase { get; set; }
        [MaxLength(300)]
        public string PhraseEn { get; set; }
        [MaxLength(100)]
        public string PhraseAuthor { get; set; }
        [MaxLength(100)]
        public string PhraseAuthorEn { get; set; }
        public bool Visible { get; set; }
        public string Content { get; set; }
        public string ContentEn { get; set; }
        public int NewsType { get; set; }
        [ForeignKey("CountryId")]
        public virtual Countries Countries { get; set; }
        [ForeignKey("PracticeAreaId")]
        public virtual PracticeAreas PracticeAreas { get; set; }
        [ForeignKey("ArticleCategoryId")]
        public virtual ArticleCategories ArticleCategories { get; set; }
        public virtual ICollection<ArticleAuthors> ArticleAuthors { get; set; }
        public virtual ICollection<ArticleBibliographics> ArticleBibliographics { get; set; }
        public virtual ArticleNewsletters ArticleNewsletters { get; set; }
    }
}
