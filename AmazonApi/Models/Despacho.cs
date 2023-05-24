using System;
using System.Collections.Generic;

#nullable disable

namespace AmazonApi.Models
{
    public partial class Despacho
    {
        public Despacho()
        {
            ConfirmacionRecepcions = new HashSet<ConfirmacionRecepcion>();
        }

        public int DespachoId { get; set; }
        public int PedidoId { get; set; }
        public int ProveedorId { get; set; }
        public int EstadoDespachoId { get; set; }
        public string ObservacionesAdicionales { get; set; }
        public DateTime FechaEntrega { get; set; }

        public virtual EstadoDespacho EstadoDespacho { get; set; }
        public virtual Pedido Pedido { get; set; }
        public virtual ProveedoresTransporte Proveedor { get; set; }
        public virtual ICollection<ConfirmacionRecepcion> ConfirmacionRecepcions { get; set; }
    }
}
