using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonApi.Models
{
    public class ProductoTipos
    {
        [Key]
        public int ProductoTipoId { get; set; }
        public string NombreTipo { get; set; }
        public bool Visible { get; set; }

        public virtual ICollection<Productos> Productos { get; set; }
    }
}
