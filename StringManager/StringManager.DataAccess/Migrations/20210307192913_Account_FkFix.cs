using Microsoft.EntityFrameworkCore.Migrations;

namespace GuitarManager.DataAccess.Migrations
{
    public partial class Account_FkFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Players_Account",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_Account",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "Account",
                table: "Accounts",
                newName: "Player");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Player",
                table: "Accounts",
                column: "Player",
                unique: true,
                filter: "[Player] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Players_Player",
                table: "Accounts",
                column: "Player",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Players_Player",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_Player",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "Player",
                table: "Accounts",
                newName: "Account");

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
    }
}
