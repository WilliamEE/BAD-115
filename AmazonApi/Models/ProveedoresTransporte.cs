using System;
using System.Collections.Generic;

#nullable disable

namespace AmazonApi.Models
{
    public partial class ProveedoresTransporte
    {
        public ProveedoresTransporte()
        {
            Despachos = new HashSet<Despacho>();
        }

        public int ProveedorId { get; set; }
        public int PaisId { get; set; }
        public string NombreProveedor { get; set; }
        public string ApellidoProveedor { get; set; }
        public string CorreoProveedor { get; set; }
        public string TelefonoProveedor { get; set; }
        public string DireccionProveedor { get; set; }
        public bool Visible { get; set; }

        public virtual Paise Pais { get; set; }
        public virtual ICollection<Despacho> Despachos { get; set; }
    }
}
