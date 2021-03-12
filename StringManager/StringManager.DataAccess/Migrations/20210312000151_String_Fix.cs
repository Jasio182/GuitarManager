using Microsoft.EntityFrameworkCore.Migrations;

namespace GuitarManager.DataAccess.Migrations
{
    public partial class String_Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstalledStrings_String_StringID",
                table: "InstalledStrings");

            migrationBuilder.DropForeignKey(
                name: "FK_String_StringManufacturers_StringManufacturerID",
                table: "String");

            migrationBuilder.DropForeignKey(
                name: "FK_String_StringTypes_StringTypeID",
                table: "String");

            migrationBuilder.DropForeignKey(
                name: "FK_StringsInSets_String_StringID",
                table: "StringsInSets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_String",
                table: "String");

            migrationBuilder.RenameTable(
                name: "String",
                newName: "Strings");

            migrationBuilder.RenameIndex(
                name: "IX_String_StringTypeID",
                table: "Strings",
                newName: "IX_Strings_StringTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_String_StringManufacturerID",
                table: "Strings",
                newName: "IX_Strings_StringManufacturerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Strings",
                table: "Strings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InstalledStrings_Strings_StringID",
                table: "InstalledStrings",
                column: "StringID",
                principalTable: "Strings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Strings_StringManufacturers_StringManufacturerID",
                table: "Strings",
                column: "StringManufacturerID",
                principalTable: "StringManufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Strings_StringTypes_StringTypeID",
                table: "Strings",
                column: "StringTypeID",
                principalTable: "StringTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StringsInSets_Strings_StringID",
                table: "StringsInSets",
                column: "StringID",
                principalTable: "Strings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstalledStrings_Strings_StringID",
                table: "InstalledStrings");

            migrationBuilder.DropForeignKey(
                name: "FK_Strings_StringManufacturers_StringManufacturerID",
                table: "Strings");

            migrationBuilder.DropForeignKey(
                name: "FK_Strings_StringTypes_StringTypeID",
                table: "Strings");

            migrationBuilder.DropForeignKey(
                name: "FK_StringsInSets_Strings_StringID",
                table: "StringsInSets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Strings",
                table: "Strings");

            migrationBuilder.RenameTable(
                name: "Strings",
                newName: "String");

            migrationBuilder.RenameIndex(
                name: "IX_Strings_StringTypeID",
                table: "String",
                newName: "IX_String_StringTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Strings_StringManufacturerID",
                table: "String",
                newName: "IX_String_StringManufacturerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_String",
                table: "String",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InstalledStrings_String_StringID",
                table: "InstalledStrings",
                column: "StringID",
                principalTable: "String",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_String_StringManufacturers_StringManufacturerID",
                table: "String",
                column: "StringManufacturerID",
                principalTable: "StringManufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_String_StringTypes_StringTypeID",
                table: "String",
                column: "StringTypeID",
                principalTable: "StringTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StringsInSets_String_StringID",
                table: "StringsInSets",
                column: "StringID",
                principalTable: "String",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
