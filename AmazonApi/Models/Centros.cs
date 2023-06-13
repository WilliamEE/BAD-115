using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace AmazonApi.Models
{
    public partial class Centros
    {
        [Key]
        public int CentroId { get; set; }
        public int PaisId { get; set; }
        public string NombreCentro { get; set; }
        public string DireccionCentro { get; set; }
        public bool Visible { get; set; }

        [ForeignKey("PaisId")]
        public virtual Paises Pais { get; set; }
        public virtual ICollection<Inventarios> Inventarios { get; set; }
    }
}
