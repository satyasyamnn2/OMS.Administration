using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OMS.Administration.Migrations.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TaxIdenfier = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    StreetName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    State = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Country = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    ZipCode = table.Column<int>(type: "integer", nullable: true),
                    ParentOrganizationId = table.Column<string>(type: "character varying(50)", nullable: true),
                    TurnOver = table.Column<double>(type: "double precision", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: true),
                    YearOfEstablishment = table.Column<int>(type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "Stores Created on data"),
                    CreatedBy = table.Column<string>(type: "text", nullable: true, comment: "Stores Created by data"),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, comment: "Stores Modified on data"),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true, comment: "Stores Modified by data")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organizations_Organizations_ParentOrganizationId",
                        column: x => x.ParentOrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    IsOwner = table.Column<bool>(type: "boolean", nullable: false),
                    OrganizationId = table.Column<string>(type: "character varying(50)", nullable: true),
                    StreetName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    State = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Country = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    ZipCode = table.Column<int>(type: "integer", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "Stores Created on data"),
                    CreatedBy = table.Column<string>(type: "text", nullable: true, comment: "Stores Created by data"),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, comment: "Stores Modified on data"),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true, comment: "Stores Modified by data")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_OrganizationId",
                table: "Contacts",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_ParentOrganizationId",
                table: "Organizations",
                column: "ParentOrganizationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
