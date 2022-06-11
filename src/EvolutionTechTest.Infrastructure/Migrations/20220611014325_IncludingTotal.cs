using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvolutionTechTest.Infrastructure.Migrations
{
    public partial class IncludingTotal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PedTotal",
                table: "Orders",
                type: "money",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PedTotal",
                table: "Orders");
        }
    }
}
