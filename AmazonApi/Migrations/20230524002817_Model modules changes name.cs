using Microsoft.EntityFrameworkCore.Migrations;

namespace AmazonApi.Migrations
{
    public partial class Modelmoduleschangesname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Moduls_ModulId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "Moduls");

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    ModulId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModulName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.ModulId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Modules_ModulId",
                table: "Items",
                column: "ModulId",
                principalTable: "Modules",
                principalColumn: "ModulId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Modules_ModulId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.CreateTable(
                name: "Moduls",
                columns: table => new
                {
                    ModulId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Icon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModulName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moduls", x => x.ModulId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Moduls_ModulId",
                table: "Items",
                column: "ModulId",
                principalTable: "Moduls",
                principalColumn: "ModulId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
