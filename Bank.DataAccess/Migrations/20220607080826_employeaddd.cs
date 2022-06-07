using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank.DataAccess.Migrations
{
    public partial class employeaddd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Wage",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Wage",
                table: "Employees");
        }
    }
}
