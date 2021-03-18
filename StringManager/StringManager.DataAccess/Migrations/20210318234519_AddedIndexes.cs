using Microsoft.EntityFrameworkCore.Migrations;

namespace GuitarManager.DataAccess.Migrations
{
    public partial class AddedIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StringsInSets_StringSetID",
                table: "StringsInSets");

            migrationBuilder.DropIndex(
                name: "IX_InstalledStrings_MyInstrumentID",
                table: "InstalledStrings");

            migrationBuilder.CreateIndex(
                name: "IX_StringsInSets_StringSetID_StringPosition",
                table: "StringsInSets",
                columns: new[] { "StringSetID", "StringPosition" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstalledStrings_MyInstrumentID_StringPosition",
                table: "InstalledStrings",
                columns: new[] { "MyInstrumentID", "StringPosition" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StringsInSets_StringSetID_StringPosition",
                table: "StringsInSets");

            migrationBuilder.DropIndex(
                name: "IX_InstalledStrings_MyInstrumentID_StringPosition",
                table: "InstalledStrings");

            migrationBuilder.CreateIndex(
                name: "IX_StringsInSets_StringSetID",
                table: "StringsInSets",
                column: "StringSetID");

            migrationBuilder.CreateIndex(
                name: "IX_InstalledStrings_MyInstrumentID",
                table: "InstalledStrings",
                column: "MyInstrumentID");
        }
    }
}
