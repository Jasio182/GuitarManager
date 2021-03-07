using Microsoft.EntityFrameworkCore.Migrations;

namespace GuitarManager.DataAccess.Migrations
{
    public partial class Account_ColumnNameFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GuitarManufacturerName",
                table: "Accounts",
                newName: "Login");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Login",
                table: "Accounts",
                newName: "GuitarManufacturerName");
        }
    }
}
