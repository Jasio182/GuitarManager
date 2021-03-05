using Microsoft.EntityFrameworkCore.Migrations;

namespace GuitarManager.DataAccess.Migrations
{
    public partial class Relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StringID",
                table: "StringsInSets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StringSetID",
                table: "StringsInSets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GuitarTypeID",
                table: "StringSets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InstrumentID",
                table: "MyInstruments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlayerID",
                table: "MyInstruments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GuitarManufacturerID",
                table: "Instruments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GuitarTypeID",
                table: "Instruments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MyInstrumentID",
                table: "InstalledStrings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SoundID",
                table: "InstalledStrings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StringID",
                table: "InstalledStrings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuitarManufacturerName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    PlayerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayStyle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CareStyle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "String",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<double>(type: "float", nullable: false),
                    BulkDensity = table.Column<double>(type: "float", nullable: false),
                    StringTypeID = table.Column<int>(type: "int", nullable: false),
                    StringManufacturerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_String", x => x.Id);
                    table.ForeignKey(
                        name: "FK_String_StringManufacturers_StringManufacturerID",
                        column: x => x.StringManufacturerID,
                        principalTable: "StringManufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_String_StringTypes_StringTypeID",
                        column: x => x.StringTypeID,
                        principalTable: "StringTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StringsInSets_StringID",
                table: "StringsInSets",
                column: "StringID");

            migrationBuilder.CreateIndex(
                name: "IX_StringsInSets_StringSetID",
                table: "StringsInSets",
                column: "StringSetID");

            migrationBuilder.CreateIndex(
                name: "IX_StringSets_GuitarTypeID",
                table: "StringSets",
                column: "GuitarTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_MyInstruments_InstrumentID",
                table: "MyInstruments",
                column: "InstrumentID");

            migrationBuilder.CreateIndex(
                name: "IX_MyInstruments_PlayerID",
                table: "MyInstruments",
                column: "PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_Instruments_GuitarManufacturerID",
                table: "Instruments",
                column: "GuitarManufacturerID");

            migrationBuilder.CreateIndex(
                name: "IX_Instruments_GuitarTypeID",
                table: "Instruments",
                column: "GuitarTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_InstalledStrings_MyInstrumentID",
                table: "InstalledStrings",
                column: "MyInstrumentID");

            migrationBuilder.CreateIndex(
                name: "IX_InstalledStrings_SoundID",
                table: "InstalledStrings",
                column: "SoundID");

            migrationBuilder.CreateIndex(
                name: "IX_InstalledStrings_StringID",
                table: "InstalledStrings",
                column: "StringID");

            migrationBuilder.CreateIndex(
                name: "IX_String_StringManufacturerID",
                table: "String",
                column: "StringManufacturerID");

            migrationBuilder.CreateIndex(
                name: "IX_String_StringTypeID",
                table: "String",
                column: "StringTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_InstalledStrings_MyInstruments_MyInstrumentID",
                table: "InstalledStrings",
                column: "MyInstrumentID",
                principalTable: "MyInstruments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InstalledStrings_Sounds_SoundID",
                table: "InstalledStrings",
                column: "SoundID",
                principalTable: "Sounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InstalledStrings_String_StringID",
                table: "InstalledStrings",
                column: "StringID",
                principalTable: "String",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instruments_GuitarManufacturers_GuitarManufacturerID",
                table: "Instruments",
                column: "GuitarManufacturerID",
                principalTable: "GuitarManufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instruments_GuitarTypes_GuitarTypeID",
                table: "Instruments",
                column: "GuitarTypeID",
                principalTable: "GuitarTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MyInstruments_Instruments_InstrumentID",
                table: "MyInstruments",
                column: "InstrumentID",
                principalTable: "Instruments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MyInstruments_Players_PlayerID",
                table: "MyInstruments",
                column: "PlayerID",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StringSets_GuitarTypes_GuitarTypeID",
                table: "StringSets",
                column: "GuitarTypeID",
                principalTable: "GuitarTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StringsInSets_String_StringID",
                table: "StringsInSets",
                column: "StringID",
                principalTable: "String",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StringsInSets_StringSets_StringSetID",
                table: "StringsInSets",
                column: "StringSetID",
                principalTable: "StringSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstalledStrings_MyInstruments_MyInstrumentID",
                table: "InstalledStrings");

            migrationBuilder.DropForeignKey(
                name: "FK_InstalledStrings_Sounds_SoundID",
                table: "InstalledStrings");

            migrationBuilder.DropForeignKey(
                name: "FK_InstalledStrings_String_StringID",
                table: "InstalledStrings");

            migrationBuilder.DropForeignKey(
                name: "FK_Instruments_GuitarManufacturers_GuitarManufacturerID",
                table: "Instruments");

            migrationBuilder.DropForeignKey(
                name: "FK_Instruments_GuitarTypes_GuitarTypeID",
                table: "Instruments");

            migrationBuilder.DropForeignKey(
                name: "FK_MyInstruments_Instruments_InstrumentID",
                table: "MyInstruments");

            migrationBuilder.DropForeignKey(
                name: "FK_MyInstruments_Players_PlayerID",
                table: "MyInstruments");

            migrationBuilder.DropForeignKey(
                name: "FK_StringSets_GuitarTypes_GuitarTypeID",
                table: "StringSets");

            migrationBuilder.DropForeignKey(
                name: "FK_StringsInSets_String_StringID",
                table: "StringsInSets");

            migrationBuilder.DropForeignKey(
                name: "FK_StringsInSets_StringSets_StringSetID",
                table: "StringsInSets");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "String");

            migrationBuilder.DropIndex(
                name: "IX_StringsInSets_StringID",
                table: "StringsInSets");

            migrationBuilder.DropIndex(
                name: "IX_StringsInSets_StringSetID",
                table: "StringsInSets");

            migrationBuilder.DropIndex(
                name: "IX_StringSets_GuitarTypeID",
                table: "StringSets");

            migrationBuilder.DropIndex(
                name: "IX_MyInstruments_InstrumentID",
                table: "MyInstruments");

            migrationBuilder.DropIndex(
                name: "IX_MyInstruments_PlayerID",
                table: "MyInstruments");

            migrationBuilder.DropIndex(
                name: "IX_Instruments_GuitarManufacturerID",
                table: "Instruments");

            migrationBuilder.DropIndex(
                name: "IX_Instruments_GuitarTypeID",
                table: "Instruments");

            migrationBuilder.DropIndex(
                name: "IX_InstalledStrings_MyInstrumentID",
                table: "InstalledStrings");

            migrationBuilder.DropIndex(
                name: "IX_InstalledStrings_SoundID",
                table: "InstalledStrings");

            migrationBuilder.DropIndex(
                name: "IX_InstalledStrings_StringID",
                table: "InstalledStrings");

            migrationBuilder.DropColumn(
                name: "StringID",
                table: "StringsInSets");

            migrationBuilder.DropColumn(
                name: "StringSetID",
                table: "StringsInSets");

            migrationBuilder.DropColumn(
                name: "GuitarTypeID",
                table: "StringSets");

            migrationBuilder.DropColumn(
                name: "InstrumentID",
                table: "MyInstruments");

            migrationBuilder.DropColumn(
                name: "PlayerID",
                table: "MyInstruments");

            migrationBuilder.DropColumn(
                name: "GuitarManufacturerID",
                table: "Instruments");

            migrationBuilder.DropColumn(
                name: "GuitarTypeID",
                table: "Instruments");

            migrationBuilder.DropColumn(
                name: "MyInstrumentID",
                table: "InstalledStrings");

            migrationBuilder.DropColumn(
                name: "SoundID",
                table: "InstalledStrings");

            migrationBuilder.DropColumn(
                name: "StringID",
                table: "InstalledStrings");
        }
    }
}
