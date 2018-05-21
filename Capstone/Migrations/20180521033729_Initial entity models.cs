using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Capstone.Migrations
{
    public partial class Initialentitymodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Providers_ProviderID",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "BcbsPrefixes");

            migrationBuilder.DropTable(
                name: "MemoChoices");

            migrationBuilder.DropTable(
                name: "AutoMemos");

            migrationBuilder.DropIndex(
                name: "IX_Patients_ProviderID",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "PhoneNumeber",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "Lens",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "ProviderID",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "PatientType",
                table: "Patients",
                newName: "Lenses");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Stores",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContactID",
                table: "Stores",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Providers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContactID",
                table: "Providers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProviderNoteID",
                table: "Patients",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Patients",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: false),
                    Location = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MemoOptions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemoOptions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Prefixes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    ProviderID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prefixes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Prefixes_Providers_ProviderID",
                        column: x => x.ProviderID,
                        principalTable: "Providers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProviderNotes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContactID = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    ProviderID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderNotes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProviderNotes_Contacts_ContactID",
                        column: x => x.ContactID,
                        principalTable: "Contacts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProviderNotes_Providers_ProviderID",
                        column: x => x.ProviderID,
                        principalTable: "Providers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stores_ContactID",
                table: "Stores",
                column: "ContactID");

            migrationBuilder.CreateIndex(
                name: "IX_Providers_ContactID",
                table: "Providers",
                column: "ContactID");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_ProviderNoteID",
                table: "Patients",
                column: "ProviderNoteID");

            migrationBuilder.CreateIndex(
                name: "IX_Prefixes_ProviderID",
                table: "Prefixes",
                column: "ProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderNotes_ContactID",
                table: "ProviderNotes",
                column: "ContactID");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderNotes_ProviderID",
                table: "ProviderNotes",
                column: "ProviderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_ProviderNotes_ProviderNoteID",
                table: "Patients",
                column: "ProviderNoteID",
                principalTable: "ProviderNotes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Providers_Contacts_ContactID",
                table: "Providers",
                column: "ContactID",
                principalTable: "Contacts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Contacts_ContactID",
                table: "Stores",
                column: "ContactID",
                principalTable: "Contacts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_ProviderNotes_ProviderNoteID",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Providers_Contacts_ContactID",
                table: "Providers");

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Contacts_ContactID",
                table: "Stores");

            migrationBuilder.DropTable(
                name: "MemoOptions");

            migrationBuilder.DropTable(
                name: "Prefixes");

            migrationBuilder.DropTable(
                name: "ProviderNotes");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Stores_ContactID",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Providers_ContactID",
                table: "Providers");

            migrationBuilder.DropIndex(
                name: "IX_Patients_ProviderNoteID",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "ContactID",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "ContactID",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "ProviderNoteID",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "Lenses",
                table: "Patients",
                newName: "PatientType");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Stores",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Stores",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Stores",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumeber",
                table: "Stores",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Stores",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ZipCode",
                table: "Stores",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Providers",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Providers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lens",
                table: "Patients",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProviderID",
                table: "Patients",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AutoMemos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoMemos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BcbsPrefixes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Prefix = table.Column<string>(nullable: true),
                    ProviderID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BcbsPrefixes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BcbsPrefixes_Providers_ProviderID",
                        column: x => x.ProviderID,
                        principalTable: "Providers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemoChoices",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AutoMemoID = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemoChoices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MemoChoices_AutoMemos_AutoMemoID",
                        column: x => x.AutoMemoID,
                        principalTable: "AutoMemos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_ProviderID",
                table: "Patients",
                column: "ProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_BcbsPrefixes_ProviderID",
                table: "BcbsPrefixes",
                column: "ProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_MemoChoices_AutoMemoID",
                table: "MemoChoices",
                column: "AutoMemoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Providers_ProviderID",
                table: "Patients",
                column: "ProviderID",
                principalTable: "Providers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
