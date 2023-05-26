using System;
using System.Collections.Generic;

#nullable disable

namespace AmazonApi.Models
{
    public partial class Paise
    {
        public Paise()
        {
            CentrosDistribucions = new HashSet<CentrosDistribucion>();
            Clientes = new HashSet<Cliente>();
            ProveedoresTransportes = new HashSet<ProveedoresTransporte>();
        }

        public int PaisId { get; set; }
        public string Nombrepais { get; set; }

        public virtual ICollection<CentrosDistribucion> CentrosDistribucions { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<ProveedoresTransporte> ProveedoresTransportes { get; set; }
    }
}
