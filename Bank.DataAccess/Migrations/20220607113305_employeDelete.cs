using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank.DataAccess.Migrations
{
    public partial class employeDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Budget",
                table: "Employees");

            migrationBuilder.AlterColumn<double>(
                name: "Wage",
                table: "Employees",
                type: "float",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Wage",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Budget",
                table: "Employees",
                type: "float",
                nullable: true);
        }
    }
}
