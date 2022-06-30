using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OMS.Administration.Migrations.Migrations
{
    public partial class AuditableFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Organizations",
                type: "text",
                nullable: true,
                comment: "Stores Created by data");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Organizations",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Stores Created on data");

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "Organizations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Organizations",
                type: "text",
                nullable: true,
                comment: "Stores Modified by data");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Organizations",
                type: "timestamp without time zone",
                nullable: true,
                comment: "Stores Modified on data");

            migrationBuilder.AddColumn<double>(
                name: "TurnOver",
                table: "Organizations",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "YearOfEstablishment",
                table: "Organizations",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Contacts",
                type: "text",
                nullable: true,
                comment: "Stores Created by data");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Contacts",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Stores Created on data");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Contacts",
                type: "text",
                nullable: true,
                comment: "Stores Modified by data");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Contacts",
                type: "timestamp without time zone",
                nullable: true,
                comment: "Stores Modified on data");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "TurnOver",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "YearOfEstablishment",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Contacts");
        }
    }
}
