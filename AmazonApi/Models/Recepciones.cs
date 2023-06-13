using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace AmazonApi.Models
{
    public partial class Recepciones
    {
        [Key]
        public int RecepcionId { get; set; }
        public int DespachoId { get; set; }
        public int ClienteId { get; set; }
        public bool Entregado { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Clientes Cliente { get; set; }
        [ForeignKey("DespachoId")]
        public virtual Despachos Despacho { get; set; }
    }
}
