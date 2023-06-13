using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace AmazonApi.Models
{
    public partial class PedidoDetalles
    {
        [Key]
        public int PedidoDetalleId { get; set; }
        public int PedidoId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }

        [ForeignKey("PedidoId")]
        public virtual Pedidos Pedido { get; set; }
        [ForeignKey("ProductoId")]
        public virtual Productos Producto { get; set; }
    }
}
