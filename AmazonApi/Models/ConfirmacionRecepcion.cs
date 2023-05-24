using System;
using System.Collections.Generic;

#nullable disable

namespace AmazonApi.Models
{
    public partial class ConfirmacionRecepcion
    {
        public int ConfirmacionRecepcionId { get; set; }
        public int DespachoId { get; set; }
        public int ClienteId { get; set; }
        public bool Entregado { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Despacho Despacho { get; set; }
    }
}
