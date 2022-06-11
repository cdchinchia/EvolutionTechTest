using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvolutionTechTest.Infrastructure.Migrations
{
    public partial class AddingProductName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProNombre",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProNombre",
                table: "Products");
        }
    }
}
