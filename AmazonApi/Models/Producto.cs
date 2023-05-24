using System;
using System.Collections.Generic;

#nullable disable

namespace AmazonApi.Models
{
    public partial class Producto
    {
        public Producto()
        {
            DetallePedidos = new HashSet<DetallePedido>();
            Iventarios = new HashSet<Iventario>();
        }

        public int ProductoId { get; set; }
        public int TipoProductoId { get; set; }
        public string NombreProducto { get; set; }
        public string CodigoBarra { get; set; }
        public bool Visible { get; set; }

        public virtual TiposProducto TipoProducto { get; set; }
        public virtual ICollection<DetallePedido> DetallePedidos { get; set; }
        public virtual ICollection<Iventario> Iventarios { get; set; }
    }
}
