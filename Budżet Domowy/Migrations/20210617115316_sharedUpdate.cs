using Microsoft.EntityFrameworkCore.Migrations;

namespace Budżet_Domowy.Migrations
{
    public partial class sharedUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isShared",
                table: "Budgets",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isShared",
                table: "Budgets");
        }
    }
}
