using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace AmazonApi.Models
{
    public partial class Productos
    {
        [Key]
        public int ProductoId { get; set; }
        public int ProductoTipoId { get; set; }
        public string NombreProducto { get; set; }
        public string CodigoBarra { get; set; }
        public bool Visible { get; set; }

        [ForeignKey("ProductoTipoId")]
        public virtual ProductoTipos ProductoTipo { get; set; }
        public virtual ICollection<PedidoDetalles> PedidoDetalles { get; set; }
        public virtual ICollection<Inventarios> Inventarios { get; set; }
    }
}
