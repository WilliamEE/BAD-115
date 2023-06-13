using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace AmazonApi.Models
{
    public partial class Despachos
    {
        [Key]
        public int DespachoId { get; set; }
        public int PedidoId { get; set; }
        public int TransporteProveedoresId { get; set; }
        public int DespachoEstadoId { get; set; }
        public string ObservacionesAdicionales { get; set; }
        public DateTime FechaEntrega { get; set; }

        [ForeignKey("DespachoEstadoId")]
        public virtual DespachoEstados DespachoEstado { get; set; }
        [ForeignKey("PedidoId")]
        public virtual Pedidos Pedido { get; set; }
        [ForeignKey("TransporteProveedoresId")]
        public virtual TransporteProveedores TransporteProveedores { get; set; }
        public virtual ICollection<Recepciones> Recepciones { get; set; }
    }
}
