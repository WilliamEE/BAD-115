using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class GeneralValues
    {
        [Key]
        public int GeneralValueId { get; set; }
        [MaxLength(50)]
        public string PurposeTitleESP { get; set; }
        public string PurposeESP { get; set; }
        [MaxLength(50)]
        public string PurposeTitleENG { get; set; }
        public string PurposeENG { get; set; }
        [MaxLength(50)]
        public string MisionTitleESP { get; set; }
        public string MisionESP { get; set; }
        [MaxLength(50)]
        public string MisionTitleENG { get; set; }
        public string MisionENG { get; set; }
        [MaxLength(50)]
        public string VisionTitleESP { get; set; }
        public string VisionESP { get; set; }
        [MaxLength(50)]
        public string VisionTitleENG { get; set; }
        public string VisionENG { get; set; }
    }
}
