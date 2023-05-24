using System;
using System.Collections.Generic;

#nullable disable

namespace AmazonApi.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            ConfirmacionRecepcions = new HashSet<ConfirmacionRecepcion>();
            Pedidos = new HashSet<Pedido>();
        }

        public int ClienteId { get; set; }
        public int PaisId { get; set; }
        public string NombreCliente { get; set; }
        public string ApellidoCliente { get; set; }
        public string CorreoCliente { get; set; }
        public string TelefonoCliente { get; set; }
        public string DireccionCliente { get; set; }
        public bool Visible { get; set; }

        public virtual Paise Pais { get; set; }
        public virtual ICollection<ConfirmacionRecepcion> ConfirmacionRecepcions { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
