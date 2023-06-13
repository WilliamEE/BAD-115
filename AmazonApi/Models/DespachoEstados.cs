using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace AmazonApi.Models
{
    public partial class DespachoEstados
    {
        [Key]
        public int DespachoEstadoId { get; set; }
        public string NombreEstado { get; set; }

        public virtual ICollection<Despachos> Despachos { get; set; }
    }
}
