using System;
using System.Collections.Generic;

#nullable disable

namespace AmazonApi.Models
{
    public partial class EstadoDespacho
    {
        public EstadoDespacho()
        {
            Despachos = new HashSet<Despacho>();
        }

        public int EstadoDespachoId { get; set; }
        public string NombreEstado { get; set; }

        public virtual ICollection<Despacho> Despachos { get; set; }
    }
}
