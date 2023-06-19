using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AmazonApi.Models
{
    public class PedidoFinal
    {
        [Key]
        public int PedidoId { get; set; }
        public int PedidoEstadoId { get; set; }
        public int ClienteId { get; set; }
        public string DireccionEntrega { get; set; }
        public string ObservacionesAdicionales { get; set; }

        [Key]
        public int PedidoDetalleId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }

        [ForeignKey("PedidoId")]
        public virtual Pedidos Pedido { get; set; }
        [ForeignKey("ProductoId")]
        public virtual Productos Producto { get; set; }


        [ForeignKey("ClienteId")]
        public virtual Clientes Cliente { get; set; }
        [ForeignKey("PedidoEstadoId")]
        public virtual PedidoEstados PedidoEstado { get; set; }
        public virtual ICollection<Despachos> Despachos { get; set; }
        public virtual ICollection<PedidoDetalles> PedidoDetalles { get; set; }
    }
}
