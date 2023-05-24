using System;
using System.Collections.Generic;

#nullable disable

namespace AmazonApi.Models
{
    public partial class Iventario
    {
        public int InventarioId { get; set; }
        public int CentroDistribucionId { get; set; }
        public int ProductoId { get; set; }
        public int Entrada { get; set; }
        public int Salida { get; set; }

        public virtual CentrosDistribucion CentroDistribucion { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
