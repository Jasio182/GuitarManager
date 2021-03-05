using Microsoft.EntityFrameworkCore.Migrations;

namespace GuitarManager.DataAccess.Migrations
{
    public partial class ForeignKey_AccountPlayer_Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountID",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PlayerID",
                table: "Accounts");

            migrationBuilder.AddColumn<int>(
                name: "Account",
                table: "Accounts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Account",
                table: "Accounts",
                column: "Account",
                unique: true,
                filter: "[Account] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Players_Account",
                table: "Accounts",
                column: "Account",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Players_Account",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_Account",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Account",
                table: "Accounts");

            migrationBuilder.AddColumn<int>(
                name: "AccountID",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlayerID",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
