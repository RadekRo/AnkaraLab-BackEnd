using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AnkaraLab_BackEnd.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class refresh3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Faqs",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Faqs",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.InsertData(
                table: "Faqs",
                columns: new[] { "Id", "Answer", "Question" },
                values: new object[,]
                {
                    { 1, "dlab-2 (maszyna znajdująca się w posiadaniu AnkaraLab.com) naświetla zdjęcia z plików zapisanych w formatach .jpg, .tif, .bmp, .psd, których wielkość nie przekracza 100 Mb (przed kompresją).", "Jakie formaty plików są odczytywane prez laba?" },
                    { 2, "Tak, nie ma konieczności przerabiania plików, jeśli aparat zapisuje je w formacie obsługiwanym przez maszynę (patrz, pkt.1). Uwaga! Maszyna nie akceptuje plików RAW. Aby uzyskać najlepsze efekty zdjęcia można skadrować, znając dokładne formaty odbitek i ew. obrobić kolorystycznie, pamiętając o kalibracji monitora.", "Czy można wywołać zdjęcia z plików prosto z aparatu?" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Faqs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Faqs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "Faqs",
                columns: new[] { "Id", "Answer", "Question" },
                values: new object[,]
                {
                    { 11, "dlab-2 (maszyna znajdująca się w posiadaniu AnkaraLab.com) naświetla zdjęcia z plików zapisanych w formatach .jpg, .tif, .bmp, .psd, których wielkość nie przekracza 100 Mb (przed kompresją).", "Jakie formaty plików są odczytywane prez laba?" },
                    { 22, "Tak, nie ma konieczności przerabiania plików, jeśli aparat zapisuje je w formacie obsługiwanym przez maszynę (patrz, pkt.1). Uwaga! Maszyna nie akceptuje plików RAW. Aby uzyskać najlepsze efekty zdjęcia można skadrować, znając dokładne formaty odbitek i ew. obrobić kolorystycznie, pamiętając o kalibracji monitora.", "Czy można wywołać zdjęcia z plików prosto z aparatu?" }
                });
        }
    }
}
