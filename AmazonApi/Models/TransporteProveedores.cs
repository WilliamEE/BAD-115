using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace AmazonApi.Models
{
    public partial class TransporteProveedores
    {
        [Key]
        public int TransporteProveedorId { get; set; }
        public int PaisId { get; set; }
        public string NombreProveedor { get; set; }
        public string ApellidoProveedor { get; set; }
        public string CorreoProveedor { get; set; }
        public string TelefonoProveedor { get; set; }
        public string DireccionProveedor { get; set; }
        public bool Visible { get; set; }

        [ForeignKey("PaisId")]
        public virtual Paises Pais { get; set; }
        public virtual ICollection<Despachos> Despachos { get; set; }
    }
}
