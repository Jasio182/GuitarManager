using Microsoft.EntityFrameworkCore.Migrations;

namespace GuitarManager.DataAccess.Migrations
{
    public partial class Player_FkFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Accounts_Player",
                table: "Accounts");

            migrationBuilder.AddColumn<int>(
                name: "Account",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_Account",
                table: "Players",
                column: "Account");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Player",
                table: "Accounts",
                column: "Player");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Accounts_Account",
                table: "Players",
                column: "Account",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Accounts_Account",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_Account",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_Player",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Account",
                table: "Players");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Player",
                table: "Accounts",
                column: "Player",
                unique: true,
                filter: "[Player] IS NOT NULL");
        }
    }
}
