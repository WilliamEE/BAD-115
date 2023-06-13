using System;
using MarketingWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AmazonApi.Models
{
    public partial class BD_AmazonContext : DbContext
    {
        public BD_AmazonContext(DbContextOptions<BD_AmazonContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Centros> Centros { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Recepciones> Recepciones { get; set; }
        public virtual DbSet<Despachos> Despachos { get; set; }
        public virtual DbSet<PedidoDetalles> PedidoDetalles { get; set; }
        public virtual DbSet<DespachoEstados> DespachoEstados { get; set; }
        public virtual DbSet<PedidoEstados> PedidoEstados { get; set; }
        public virtual DbSet<Paises> Paises { get; set; }
        public virtual DbSet<Pedidos> Pedidos { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<TransporteProveedores> TransporteProveedores { get; set; }
        public virtual DbSet<ProductoTipos> ProductoTipos { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<Modules> Modules { get; set; }
        public DbSet<Rols> Rols { get; set; }
        public DbSet<RolsItems> RolsItems { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserItems> UserItems { get; set; }
        public DbSet<Inventarios> Inventarios { get; set; }
    }
}
