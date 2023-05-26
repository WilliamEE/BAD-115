using Microsoft.EntityFrameworkCore.Migrations;

namespace AmazonApi.Migrations
{
    public partial class Fixingmodelpedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_estadoPedidoId",
                table: "Pedidos",
                column: "estadoPedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_EstadoPedidos_estadoPedidoId",
                table: "Pedidos",
                column: "estadoPedidoId",
                principalTable: "EstadoPedidos",
                principalColumn: "estadoPedidoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_EstadoPedidos_estadoPedidoId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_estadoPedidoId",
                table: "Pedidos");
        }
    }
}
