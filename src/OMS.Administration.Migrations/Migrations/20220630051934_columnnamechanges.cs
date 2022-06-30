using Microsoft.EntityFrameworkCore.Migrations;

namespace OMS.Administration.Migrations.Migrations
{
    public partial class columnnamechanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OfficeAddress_ZipCode",
                table: "Organizations",
                newName: "ZipCode");

            migrationBuilder.RenameColumn(
                name: "OfficeAddress_Street",
                table: "Organizations",
                newName: "StreetName");

            migrationBuilder.RenameColumn(
                name: "OfficeAddress_State",
                table: "Organizations",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "OfficeAddress_Country",
                table: "Organizations",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "OfficeAddress_City",
                table: "Organizations",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "ContactAddress_ZipCode",
                table: "Contacts",
                newName: "ZipCode");

            migrationBuilder.RenameColumn(
                name: "ContactAddress_Street",
                table: "Contacts",
                newName: "StreetName");

            migrationBuilder.RenameColumn(
                name: "ContactAddress_State",
                table: "Contacts",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "ContactAddress_Country",
                table: "Contacts",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "ContactAddress_City",
                table: "Contacts",
                newName: "City");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "Organizations",
                newName: "OfficeAddress_ZipCode");

            migrationBuilder.RenameColumn(
                name: "StreetName",
                table: "Organizations",
                newName: "OfficeAddress_Street");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Organizations",
                newName: "OfficeAddress_State");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Organizations",
                newName: "OfficeAddress_Country");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Organizations",
                newName: "OfficeAddress_City");

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "Contacts",
                newName: "ContactAddress_ZipCode");

            migrationBuilder.RenameColumn(
                name: "StreetName",
                table: "Contacts",
                newName: "ContactAddress_Street");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Contacts",
                newName: "ContactAddress_State");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Contacts",
                newName: "ContactAddress_Country");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Contacts",
                newName: "ContactAddress_City");
        }
    }
}
