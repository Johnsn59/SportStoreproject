using Microsoft.EntityFrameworkCore.Migrations;

namespace SportStore.Migrations
{
    public partial class TestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Category", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Watersports", "A 1-Person Boat", "Kayak", 275m },
                    { 2, "Watersports", "Protective AND Fashionable", "Life Jacket", 48.95m },
                    { 3, "Soccer", "FIFA Approved Size And Weight", "Soccer Ball", 34.95m },
                    { 4, "Soccer", "Like The Pros", "Corner Flags", 19.50m },
                    { 5, "Running", "A New Level Of Comfort", "Running Shoes", 89.95m },
                    { 6, "Football", "Broncos Logo", "Football", 59.95m },
                    { 7, "Baseball", "Official Size & Weight", "Baseball", 9.95m },
                    { 8, "Baseball", "Genuine Leather", "Baseball Glove", 94.95m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8);
        }
    }
}
