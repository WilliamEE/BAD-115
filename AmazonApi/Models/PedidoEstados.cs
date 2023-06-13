using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace AmazonApi.Models
{
    public partial class PedidoEstados
    {
        [Key]
        public int PedidoEstadoId { get; set; }
        public string NombreEstado { get; set; }
    }
}
