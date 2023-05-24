using System;
using System.Collections.Generic;

#nullable disable

namespace AmazonApi.Models
{
    public partial class CentrosDistribucion
    {
        public CentrosDistribucion()
        {
            Iventarios = new HashSet<Iventario>();
        }

        public int CentroDistribucionId { get; set; }
        public int PaisId { get; set; }
        public string NombreCentro { get; set; }
        public string DireccionCentro { get; set; }
        public bool Visible { get; set; }

        public virtual Paise Pais { get; set; }
        public virtual ICollection<Iventario> Iventarios { get; set; }
    }
}
