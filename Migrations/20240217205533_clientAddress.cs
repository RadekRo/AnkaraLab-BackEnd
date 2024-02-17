using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnkaraLab_BackEnd.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class clientAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApartamentNumber",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HouseNumber",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApartamentNumber",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "HouseNumber",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Clients");
        }
    }
}
