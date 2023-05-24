using System;
using System.Collections.Generic;

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
        public virtual ICollection<Despacho> Despachos { get; set; }
        public virtual ICollection<DetallePedido> DetallePedidos { get; set; }
    }
}
