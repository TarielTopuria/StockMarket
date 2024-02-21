using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "CompanyName", "Industry", "LastDiv", "MarketCap", "Purchase", "Symbol" },
                values: new object[,]
                {
                    { 1, "Apple Inc.", "Technology", 0.82m, 2000000000000L, 150.00m, "AAPL" },
                    { 2, "Microsoft Corporation", "Technology", 1.24m, 1800000000000L, 250.00m, "MSFT" },
                    { 3, "Amazon.com, Inc.", "Retail", 0.00m, 1600000000000L, 3100.00m, "AMZN" },
                    { 4, "Alphabet Inc.", "Technology", 0.00m, 1500000000000L, 2800.00m, "GOOGL" },
                    { 5, "Meta Platforms, Inc.", "Technology", 0.00m, 800000000000L, 325.00m, "FB" },
                    { 6, "Tesla, Inc.", "Automotive", 0.00m, 600000000000L, 900.00m, "TSLA" },
                    { 7, "Berkshire Hathaway Inc.", "Conglomerate", 0.00m, 550000000000L, 350000.00m, "BRK.A" },
                    { 8, "Visa Inc.", "Financial Services", 1.28m, 450000000000L, 220.00m, "V" },
                    { 9, "Johnson & Johnson", "Healthcare", 3.80m, 400000000000L, 165.00m, "JNJ" },
                    { 10, "Walmart Inc.", "Retail", 2.16m, 350000000000L, 140.00m, "WMT" },
                    { 11, "NVIDIA Corporation", "Technology", 0.16m, 300000000000L, 500.00m, "NVDA" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreationTime", "StockId", "Title" },
                values: new object[,]
                {
                    { 1, "Leading the tech industry.", new DateTime(2024, 2, 21, 21, 54, 49, 539, DateTimeKind.Local).AddTicks(6831), 1, "Innovative" },
                    { 2, "Consistent growth over the years.", new DateTime(2024, 2, 21, 21, 54, 49, 539, DateTimeKind.Local).AddTicks(6834), 2, "Solid Performance" },
                    { 3, "Dominating the retail space.", new DateTime(2024, 2, 21, 21, 54, 49, 539, DateTimeKind.Local).AddTicks(6835), 3, "Expansive Reach" },
                    { 4, "Continuously innovating.", new DateTime(2024, 2, 21, 21, 54, 49, 539, DateTimeKind.Local).AddTicks(6837), 4, "Tech Giant" },
                    { 5, "Changing how we connect.", new DateTime(2024, 2, 21, 21, 54, 49, 539, DateTimeKind.Local).AddTicks(6838), 5, "Social Impact" },
                    { 6, "Transforming the auto industry.", new DateTime(2024, 2, 21, 21, 54, 49, 539, DateTimeKind.Local).AddTicks(6840), 6, "Revolutionary" },
                    { 7, "A diverse portfolio.", new DateTime(2024, 2, 21, 21, 54, 49, 539, DateTimeKind.Local).AddTicks(6842), 7, "Stable Investment" },
                    { 8, "A key player in global finance.", new DateTime(2024, 2, 21, 21, 54, 49, 539, DateTimeKind.Local).AddTicks(6843), 8, "Financial Leader" },
                    { 9, "Reliable and consistent.", new DateTime(2024, 2, 21, 21, 54, 49, 539, DateTimeKind.Local).AddTicks(6845), 9, "Trusted Brand" },
                    { 10, "A cornerstone of retail.", new DateTime(2024, 2, 21, 21, 54, 49, 539, DateTimeKind.Local).AddTicks(6846), 10, "Retail Powerhouse" },
                    { 11, "Leading in graphics technology.", new DateTime(2024, 2, 21, 21, 54, 49, 539, DateTimeKind.Local).AddTicks(6848), 11, "Tech Innovator" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 11);
        }
    }
}
