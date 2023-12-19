using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnkaraLab_BackEnd.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class ClientTableUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Login",
                table: "Clients",
                newName: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Clients",
                newName: "Login");
        }
    }
}
