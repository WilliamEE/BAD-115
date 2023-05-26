using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace AmazonApi.Models
{
    public partial class Pedido
    {
        public Pedido()
        {
            Despachos = new HashSet<Despacho>();
            DetallePedidos = new HashSet<DetallePedido>();
        }

        public int PedidoId { get; set; }
        public int EstadoPedidoId { get; set; }
        public int ClienteId { get; set; }
        public string DireccionEntrega { get; set; }
        public string ObservacionesAdicionales { get; set; }

        public virtual Cliente Cliente { get; set; }
        [ForeignKey("EstadoPedidoId")]
        public virtual EstadoPedido EstadoPedido { get; set; }
        public virtual ICollection<Despacho> Despachos { get; set; }
        public virtual ICollection<DetallePedido> DetallePedidos { get; set; }
    }
}
