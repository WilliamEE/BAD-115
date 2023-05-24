using System;
using System.Collections.Generic;

#nullable disable

namespace AmazonApi.Models
{
    public partial class TiposProducto
    {
        public TiposProducto()
        {
            Productos = new HashSet<Producto>();
        }

        public int TipoProductoId { get; set; }
        public string NombreTipo { get; set; }
        public bool Visible { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
