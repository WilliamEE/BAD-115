using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class Recognitions
    {
        [Key]
        public int RecognitionId { get; set; }
        [MaxLength(500)]
        public string RecognitionName { get; set; }
        [MaxLength(500)]
        public string RecognitionNameEn { get; set; }
        public string RecognitionImage { get; set; }
        public int Visible { get; set; }
    }
}
