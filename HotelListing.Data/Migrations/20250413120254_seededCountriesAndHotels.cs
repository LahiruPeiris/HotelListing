using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelListing.API.Migrations
{
    /// <inheritdoc />
    public partial class seededCountriesAndHotels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "ShortName" },
                values: new object[,]
                {
                    { 1, "United States", "US" },
                    { 2, "United Kingdom", "UK" },
                    { 3, "Canada", "CA" },
                    { 4, "Australia", "AU" },
                    { 5, "Germany", "DE" },
                    { 6, "France", "FR" },
                    { 7, "Italy", "IT" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "CountryId", "Name", "Rating" },
                values: new object[,]
                {
                    { 1, "123 Main St, Los Angeles, CA", 1, "Hotel California", 4.5 },
                    { 2, "150 Piccadilly, London W1J 9BR, UK", 2, "The Ritz London", 5.0 },
                    { 3, "405 Spray Ave, Banff, AB T1L 1J4, Canada", 3, "Fairmont Banff Springs", 4.7999999999999998 },
                    { 4, "Bennelong Point, Sydney NSW 2000, Australia", 4, "Sydney Opera House Hotel", 4.7000000000000002 },
                    { 5, "Unter den Linden 77, 10117 Berlin, Germany", 5, "Hotel Adlon Kempinski", 4.9000000000000004 },
                    { 6, "228 Rue de Rivoli, 75001 Paris, France", 6, "Le Meurice", 4.5999999999999996 },
                    { 7, "Riva degli Schiavoni, 4196, 30122 Venezia VE, Italy", 7, "Hotel Danieli", 4.7999999999999998 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
