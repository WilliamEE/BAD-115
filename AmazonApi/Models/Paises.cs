using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace AmazonApi.Models
{
    public partial class Paises
    {
        [Key]
        public int PaisId { get; set; }
        public string Nombrepais { get; set; }

        public virtual ICollection<Centros> Centros { get; set; }
        public virtual ICollection<Clientes> Clientes { get; set; }
        public virtual ICollection<TransporteProveedores> TransporteProveedores { get; set; }
    }
}
