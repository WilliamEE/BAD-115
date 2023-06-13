using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace AmazonApi.Models
{
    public partial class Clientes
    {
        [Key]
        public int ClienteId { get; set; }
        public int PaisId { get; set; }
        public string NombreCliente { get; set; }
        public string ApellidoCliente { get; set; }
        public string CorreoCliente { get; set; }
        public string TelefonoCliente { get; set; }
        public string DireccionCliente { get; set; }
        public bool Visible { get; set; }

        [ForeignKey("PaisId")]
        public virtual Paises Pais { get; set; }
        public virtual ICollection<Recepciones> Recepciones { get; set; }
        public virtual ICollection<Pedidos> Pedidos { get; set; }
    }
}
