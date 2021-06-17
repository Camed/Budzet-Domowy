using Microsoft.EntityFrameworkCore.Migrations;

namespace Budżet_Domowy.Migrations
{
    public partial class BudgetPartUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFinished",
                table: "BudgetParts",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFinished",
                table: "BudgetParts");
        }
    }
}
