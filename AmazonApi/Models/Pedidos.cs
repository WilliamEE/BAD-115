using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace AmazonApi.Models
{
    public partial class Pedidos
    {
        [Key]
        public int PedidoId { get; set; }
        public int PedidoEstadoId { get; set; }
        public int ClienteId { get; set; }
        public string DireccionEntrega { get; set; }
        public string ObservacionesAdicionales { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Clientes Cliente { get; set; }
        [ForeignKey("PedidoEstadoId")]
        public virtual PedidoEstados PedidoEstado { get; set; }
        public virtual ICollection<Despachos> Despachos { get; set; }
        public virtual ICollection<PedidoDetalles> PedidoDetalles { get; set; }
    }
}
