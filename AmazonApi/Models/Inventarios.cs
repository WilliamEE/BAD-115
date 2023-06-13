using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonApi.Models
{
    public class Inventarios
    {
        [Key]
        public int InventarioId { get; set; }
        public int CentroId { get; set; }
        public int ProductoId { get; set; }
        public int Entrada { get; set; }
        public int Salida { get; set; }

        [ForeignKey("CentroId")]
        public virtual Centros Centro { get; set; }
        [ForeignKey("ProductoId")]
        public virtual Productos Producto { get; set; }
    }
}
