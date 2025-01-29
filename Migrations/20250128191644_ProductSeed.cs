using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class ProductSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "SpecialTag" },
                values: new object[,]
                {
                    { 100, 4, "Comfortable cotton t-shirt", "/images/product/shirt.png", "Tshirt", 19.99m, "New" },
                    { 101, 8, "Warm winter jacket", "/images/product/shirt.png", "Jacket", 49.99m, "Sale" },
                    { 102, 9, "Stylish denim jeans", "/images/product/shirt.png", "Jeans", 39.99m, null },
                    { 103, 10, "Classic formal trousers", "/images/product/shirt.png", "Trousers", 29.99m, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "SpecialTag" },
                values: new object[,]
                {
                    { 3, 4, "Comfortable cotton t-shirt", "/images/product/shirt.png", "Tshirt", 19.99m, "New" },
                    { 4, 8, "Warm winter jacket", "/images/product/shirt.png", "Jacket", 49.99m, "Sale" },
                    { 5, 9, "Stylish denim jeans", "/images/product/shirt.png", "Jeans", 39.99m, null },
                    { 6, 10, "Classic formal trousers", "/images/product/shirt.png", "Trousers", 29.99m, null }
                });
        }
    }
}
