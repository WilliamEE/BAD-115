using Microsoft.EntityFrameworkCore.Migrations;

namespace AmazonApi.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OfficeId",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OfficeId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
