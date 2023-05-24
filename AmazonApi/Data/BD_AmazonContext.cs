using System;
using MarketingWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AmazonApi.Models
{
    public partial class BD_AmazonContext : DbContext
    {
        public BD_AmazonContext()
        {
        }

        public BD_AmazonContext(DbContextOptions<BD_AmazonContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CentrosDistribucion> CentrosDistribucions { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<ConfirmacionRecepcion> ConfirmacionRecepcions { get; set; }
        public virtual DbSet<Despacho> Despachos { get; set; }
        public virtual DbSet<DetallePedido> DetallePedidos { get; set; }
        public virtual DbSet<EstadoDespacho> EstadoDespachos { get; set; }
        public virtual DbSet<EstadoPedido> EstadoPedidos { get; set; }
        public virtual DbSet<Iventario> Iventarios { get; set; }
        public virtual DbSet<Paise> Paises { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<ProveedoresTransporte> ProveedoresTransportes { get; set; }
        public virtual DbSet<TiposProducto> TiposProductos { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<Moduls> Moduls { get; set; }
        public DbSet<Rols> Rols { get; set; }
        public DbSet<RolsItems> RolsItems { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserItems> UserItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=BD_Ama-zon;user=sa;password=Bufete2018");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<CentrosDistribucion>(entity =>
            {
                entity.HasKey(e => e.CentroDistribucionId)
                    .HasName("PK__CentrosD__B74C72AEF603E726");

                entity.ToTable("CentrosDistribucion");

                entity.Property(e => e.CentroDistribucionId)
                    .ValueGeneratedNever()
                    .HasColumnName("centroDistribucionId");

                entity.Property(e => e.DireccionCentro)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("direccionCentro");

                entity.Property(e => e.NombreCentro)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("nombreCentro");

                entity.Property(e => e.PaisId).HasColumnName("paisId");

                entity.Property(e => e.Visible).HasColumnName("visible");

                entity.HasOne(d => d.Pais)
                    .WithMany(p => p.CentrosDistribucions)
                    .HasForeignKey(d => d.PaisId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CentrosDi__paisI__3C69FB99");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.ClienteId)
                    .ValueGeneratedNever()
                    .HasColumnName("clienteId");

                entity.Property(e => e.ApellidoCliente)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("apellidoCliente");

                entity.Property(e => e.CorreoCliente)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("correoCliente");

                entity.Property(e => e.DireccionCliente)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("direccionCliente");

                entity.Property(e => e.NombreCliente)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("nombreCliente");

                entity.Property(e => e.PaisId).HasColumnName("paisId");

                entity.Property(e => e.TelefonoCliente)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("telefonoCliente");

                entity.Property(e => e.Visible).HasColumnName("visible");

                entity.HasOne(d => d.Pais)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.PaisId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Clientes__paisId__398D8EEE");
            });

            modelBuilder.Entity<ConfirmacionRecepcion>(entity =>
            {
                entity.ToTable("ConfirmacionRecepcion");

                entity.Property(e => e.ConfirmacionRecepcionId)
                    .ValueGeneratedNever()
                    .HasColumnName("confirmacionRecepcionId");

                entity.Property(e => e.ClienteId).HasColumnName("clienteId");

                entity.Property(e => e.DespachoId).HasColumnName("despachoId");

                entity.Property(e => e.Entregado).HasColumnName("entregado");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.ConfirmacionRecepcions)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Confirmac__clien__5AEE82B9");

                entity.HasOne(d => d.Despacho)
                    .WithMany(p => p.ConfirmacionRecepcions)
                    .HasForeignKey(d => d.DespachoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Confirmac__despa__59FA5E80");
            });

            modelBuilder.Entity<Despacho>(entity =>
            {
                entity.Property(e => e.DespachoId)
                    .ValueGeneratedNever()
                    .HasColumnName("despachoId");

                entity.Property(e => e.EstadoDespachoId).HasColumnName("estadoDespachoId");

                entity.Property(e => e.FechaEntrega)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaEntrega");

                entity.Property(e => e.ObservacionesAdicionales)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("observacionesAdicionales");

                entity.Property(e => e.PedidoId).HasColumnName("pedidoId");

                entity.Property(e => e.ProveedorId).HasColumnName("proveedorId");

                entity.HasOne(d => d.EstadoDespacho)
                    .WithMany(p => p.Despachos)
                    .HasForeignKey(d => d.EstadoDespachoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Despachos__estad__571DF1D5");

                entity.HasOne(d => d.Pedido)
                    .WithMany(p => p.Despachos)
                    .HasForeignKey(d => d.PedidoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Despachos__pedid__5535A963");

                entity.HasOne(d => d.Proveedor)
                    .WithMany(p => p.Despachos)
                    .HasForeignKey(d => d.ProveedorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Despachos__prove__5629CD9C");
            });

            modelBuilder.Entity<DetallePedido>(entity =>
            {
                entity.Property(e => e.DetallePedidoId)
                    .ValueGeneratedNever()
                    .HasColumnName("detallePedidoId");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.PedidoId).HasColumnName("pedidoId");

                entity.Property(e => e.ProductoId).HasColumnName("productoId");

                entity.HasOne(d => d.Pedido)
                    .WithMany(p => p.DetallePedidos)
                    .HasForeignKey(d => d.PedidoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DetallePe__pedid__4CA06362");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.DetallePedidos)
                    .HasForeignKey(d => d.ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DetallePe__produ__4D94879B");
            });

            modelBuilder.Entity<EstadoDespacho>(entity =>
            {
                entity.ToTable("EstadoDespacho");

                entity.Property(e => e.EstadoDespachoId)
                    .ValueGeneratedNever()
                    .HasColumnName("estadoDespachoId");

                entity.Property(e => e.NombreEstado)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nombreEstado");
            });

            modelBuilder.Entity<EstadoPedido>(entity =>
            {
                entity.Property(e => e.EstadoPedidoId)
                    .ValueGeneratedNever()
                    .HasColumnName("estadoPedidoId");

                entity.Property(e => e.NombreEstado)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nombreEstado");
            });

            modelBuilder.Entity<Iventario>(entity =>
            {
                entity.HasKey(e => e.InventarioId)
                    .HasName("PK__Iventari__23747585FFBA487B");

                entity.ToTable("Iventario");

                entity.Property(e => e.InventarioId)
                    .ValueGeneratedNever()
                    .HasColumnName("inventarioId");

                entity.Property(e => e.CentroDistribucionId).HasColumnName("centroDistribucionId");

                entity.Property(e => e.Entrada).HasColumnName("entrada");

                entity.Property(e => e.ProductoId).HasColumnName("productoId");

                entity.Property(e => e.Salida).HasColumnName("salida");

                entity.HasOne(d => d.CentroDistribucion)
                    .WithMany(p => p.Iventarios)
                    .HasForeignKey(d => d.CentroDistribucionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Iventario__centr__440B1D61");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.Iventarios)
                    .HasForeignKey(d => d.ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Iventario__produ__44FF419A");
            });

            modelBuilder.Entity<Paise>(entity =>
            {
                entity.HasKey(e => e.PaisId)
                    .HasName("PK__Paises__45785B8B0CC32178");

                entity.Property(e => e.PaisId)
                    .ValueGeneratedNever()
                    .HasColumnName("paisId");

                entity.Property(e => e.Nombrepais)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombrepais");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.Property(e => e.PedidoId)
                    .ValueGeneratedNever()
                    .HasColumnName("pedidoId");

                entity.Property(e => e.ClienteId).HasColumnName("clienteId");

                entity.Property(e => e.DireccionEntrega)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("direccionEntrega");

                entity.Property(e => e.EstadoPedidoId).HasColumnName("estadoPedidoId");

                entity.Property(e => e.ObservacionesAdicionales)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("observacionesAdicionales");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pedidos__cliente__47DBAE45");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Producto");

                entity.Property(e => e.ProductoId)
                    .ValueGeneratedNever()
                    .HasColumnName("productoId");

                entity.Property(e => e.CodigoBarra)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("codigoBarra");

                entity.Property(e => e.NombreProducto)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nombreProducto");

                entity.Property(e => e.TipoProductoId).HasColumnName("tipoProductoId");

                entity.Property(e => e.Visible).HasColumnName("visible");

                entity.HasOne(d => d.TipoProducto)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.TipoProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Producto__tipoPr__412EB0B6");
            });

            modelBuilder.Entity<ProveedoresTransporte>(entity =>
            {
                entity.HasKey(e => e.ProveedorId)
                    .HasName("PK__Proveedo__8253255D2133A20A");

                entity.ToTable("ProveedoresTransporte");

                entity.Property(e => e.ProveedorId)
                    .ValueGeneratedNever()
                    .HasColumnName("proveedorId");

                entity.Property(e => e.ApellidoProveedor)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("apellidoProveedor");

                entity.Property(e => e.CorreoProveedor)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("correoProveedor");

                entity.Property(e => e.DireccionProveedor)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("direccionProveedor");

                entity.Property(e => e.NombreProveedor)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("nombreProveedor");

                entity.Property(e => e.PaisId).HasColumnName("paisId");

                entity.Property(e => e.TelefonoProveedor)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("telefonoProveedor");

                entity.Property(e => e.Visible).HasColumnName("visible");

                entity.HasOne(d => d.Pais)
                    .WithMany(p => p.ProveedoresTransportes)
                    .HasForeignKey(d => d.PaisId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Proveedor__paisI__52593CB8");
            });

            modelBuilder.Entity<TiposProducto>(entity =>
            {
                entity.HasKey(e => e.TipoProductoId)
                    .HasName("PK__tiposPro__0978E14E2B43D5C4");

                entity.ToTable("tiposProducto");

                entity.Property(e => e.TipoProductoId)
                    .ValueGeneratedNever()
                    .HasColumnName("tipoProductoId");

                entity.Property(e => e.NombreTipo)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nombreTipo");

                entity.Property(e => e.Visible).HasColumnName("visible");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
