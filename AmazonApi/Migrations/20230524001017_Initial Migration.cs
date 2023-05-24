using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AmazonApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadoDespacho",
                columns: table => new
                {
                    estadoDespachoId = table.Column<int>(type: "int", nullable: false),
                    nombreEstado = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoDespacho", x => x.estadoDespachoId);
                });

            migrationBuilder.CreateTable(
                name: "EstadoPedidos",
                columns: table => new
                {
                    estadoPedidoId = table.Column<int>(type: "int", nullable: false),
                    nombreEstado = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoPedidos", x => x.estadoPedidoId);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    paisId = table.Column<int>(type: "int", nullable: false),
                    nombrepais = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Paises__45785B8B0CC32178", x => x.paisId);
                });

            migrationBuilder.CreateTable(
                name: "tiposProducto",
                columns: table => new
                {
                    tipoProductoId = table.Column<int>(type: "int", nullable: false),
                    nombreTipo = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    visible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tiposPro__0978E14E2B43D5C4", x => x.tipoProductoId);
                });

            migrationBuilder.CreateTable(
                name: "CentrosDistribucion",
                columns: table => new
                {
                    centroDistribucionId = table.Column<int>(type: "int", nullable: false),
                    paisId = table.Column<int>(type: "int", nullable: false),
                    nombreCentro = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    direccionCentro = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    visible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CentrosD__B74C72AEF603E726", x => x.centroDistribucionId);
                    table.ForeignKey(
                        name: "FK__CentrosDi__paisI__3C69FB99",
                        column: x => x.paisId,
                        principalTable: "Paises",
                        principalColumn: "paisId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    clienteId = table.Column<int>(type: "int", nullable: false),
                    paisId = table.Column<int>(type: "int", nullable: false),
                    nombreCliente = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    apellidoCliente = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    correoCliente = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    telefonoCliente = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    direccionCliente = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    visible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.clienteId);
                    table.ForeignKey(
                        name: "FK__Clientes__paisId__398D8EEE",
                        column: x => x.paisId,
                        principalTable: "Paises",
                        principalColumn: "paisId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProveedoresTransporte",
                columns: table => new
                {
                    proveedorId = table.Column<int>(type: "int", nullable: false),
                    paisId = table.Column<int>(type: "int", nullable: false),
                    nombreProveedor = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    apellidoProveedor = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    correoProveedor = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    telefonoProveedor = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    direccionProveedor = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    visible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Proveedo__8253255D2133A20A", x => x.proveedorId);
                    table.ForeignKey(
                        name: "FK__Proveedor__paisI__52593CB8",
                        column: x => x.paisId,
                        principalTable: "Paises",
                        principalColumn: "paisId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    productoId = table.Column<int>(type: "int", nullable: false),
                    tipoProductoId = table.Column<int>(type: "int", nullable: false),
                    nombreProducto = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    codigoBarra = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    visible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.productoId);
                    table.ForeignKey(
                        name: "FK__Producto__tipoPr__412EB0B6",
                        column: x => x.tipoProductoId,
                        principalTable: "tiposProducto",
                        principalColumn: "tipoProductoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    pedidoId = table.Column<int>(type: "int", nullable: false),
                    estadoPedidoId = table.Column<int>(type: "int", nullable: false),
                    clienteId = table.Column<int>(type: "int", nullable: false),
                    direccionEntrega = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    observacionesAdicionales = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.pedidoId);
                    table.ForeignKey(
                        name: "FK__Pedidos__cliente__47DBAE45",
                        column: x => x.clienteId,
                        principalTable: "Clientes",
                        principalColumn: "clienteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Iventario",
                columns: table => new
                {
                    inventarioId = table.Column<int>(type: "int", nullable: false),
                    centroDistribucionId = table.Column<int>(type: "int", nullable: false),
                    productoId = table.Column<int>(type: "int", nullable: false),
                    entrada = table.Column<int>(type: "int", nullable: false),
                    salida = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Iventari__23747585FFBA487B", x => x.inventarioId);
                    table.ForeignKey(
                        name: "FK__Iventario__centr__440B1D61",
                        column: x => x.centroDistribucionId,
                        principalTable: "CentrosDistribucion",
                        principalColumn: "centroDistribucionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Iventario__produ__44FF419A",
                        column: x => x.productoId,
                        principalTable: "Producto",
                        principalColumn: "productoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Despachos",
                columns: table => new
                {
                    despachoId = table.Column<int>(type: "int", nullable: false),
                    pedidoId = table.Column<int>(type: "int", nullable: false),
                    proveedorId = table.Column<int>(type: "int", nullable: false),
                    estadoDespachoId = table.Column<int>(type: "int", nullable: false),
                    observacionesAdicionales = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    fechaEntrega = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Despachos", x => x.despachoId);
                    table.ForeignKey(
                        name: "FK__Despachos__estad__571DF1D5",
                        column: x => x.estadoDespachoId,
                        principalTable: "EstadoDespacho",
                        principalColumn: "estadoDespachoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Despachos__pedid__5535A963",
                        column: x => x.pedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "pedidoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Despachos__prove__5629CD9C",
                        column: x => x.proveedorId,
                        principalTable: "ProveedoresTransporte",
                        principalColumn: "proveedorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetallePedidos",
                columns: table => new
                {
                    detallePedidoId = table.Column<int>(type: "int", nullable: false),
                    pedidoId = table.Column<int>(type: "int", nullable: false),
                    productoId = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallePedidos", x => x.detallePedidoId);
                    table.ForeignKey(
                        name: "FK__DetallePe__pedid__4CA06362",
                        column: x => x.pedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "pedidoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__DetallePe__produ__4D94879B",
                        column: x => x.productoId,
                        principalTable: "Producto",
                        principalColumn: "productoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConfirmacionRecepcion",
                columns: table => new
                {
                    confirmacionRecepcionId = table.Column<int>(type: "int", nullable: false),
                    despachoId = table.Column<int>(type: "int", nullable: false),
                    clienteId = table.Column<int>(type: "int", nullable: false),
                    entregado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfirmacionRecepcion", x => x.confirmacionRecepcionId);
                    table.ForeignKey(
                        name: "FK__Confirmac__clien__5AEE82B9",
                        column: x => x.clienteId,
                        principalTable: "Clientes",
                        principalColumn: "clienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Confirmac__despa__59FA5E80",
                        column: x => x.despachoId,
                        principalTable: "Despachos",
                        principalColumn: "despachoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CentrosDistribucion_paisId",
                table: "CentrosDistribucion",
                column: "paisId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_paisId",
                table: "Clientes",
                column: "paisId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfirmacionRecepcion_clienteId",
                table: "ConfirmacionRecepcion",
                column: "clienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfirmacionRecepcion_despachoId",
                table: "ConfirmacionRecepcion",
                column: "despachoId");

            migrationBuilder.CreateIndex(
                name: "IX_Despachos_estadoDespachoId",
                table: "Despachos",
                column: "estadoDespachoId");

            migrationBuilder.CreateIndex(
                name: "IX_Despachos_pedidoId",
                table: "Despachos",
                column: "pedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Despachos_proveedorId",
                table: "Despachos",
                column: "proveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedidos_pedidoId",
                table: "DetallePedidos",
                column: "pedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedidos_productoId",
                table: "DetallePedidos",
                column: "productoId");

            migrationBuilder.CreateIndex(
                name: "IX_Iventario_centroDistribucionId",
                table: "Iventario",
                column: "centroDistribucionId");

            migrationBuilder.CreateIndex(
                name: "IX_Iventario_productoId",
                table: "Iventario",
                column: "productoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_clienteId",
                table: "Pedidos",
                column: "clienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_tipoProductoId",
                table: "Producto",
                column: "tipoProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProveedoresTransporte_paisId",
                table: "ProveedoresTransporte",
                column: "paisId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfirmacionRecepcion");

            migrationBuilder.DropTable(
                name: "DetallePedidos");

            migrationBuilder.DropTable(
                name: "EstadoPedidos");

            migrationBuilder.DropTable(
                name: "Iventario");

            migrationBuilder.DropTable(
                name: "Despachos");

            migrationBuilder.DropTable(
                name: "CentrosDistribucion");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "EstadoDespacho");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "ProveedoresTransporte");

            migrationBuilder.DropTable(
                name: "tiposProducto");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Paises");
        }
    }
}
