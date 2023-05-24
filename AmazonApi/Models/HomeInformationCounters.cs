using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingWebApi.Models
{
    public class HomeInformationCounters
    {
        [Key]
        public int CounterId { get; set; }
        public int HomeInformationId { get; set; }
        public string DescriptionESP { get; set; }
        public string DescriptionENG { get; set; }
        public int Quantity { get; set; }
        public bool PlusIcon { get; set; }
        [ForeignKey("HomeInformationId")]
        public virtual HomeInformation HomeInformation { get; set; }
    }
}
