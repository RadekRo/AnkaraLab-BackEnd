using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnkaraLab_BackEnd.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class NewCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 3, "Gadżety z plików cyfrowych", "Gadżety" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Deadline", "Description", "IsAvaliable", "PhotoHeight", "PhotoWidth", "Price", "Size" },
                values: new object[] { 3, 3, 3, "Fotokula śnieżna", true, 100, 100, 25.0, "10x10" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
