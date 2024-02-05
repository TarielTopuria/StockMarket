using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class seedcommentdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreationTime", "StockId", "Title" },
                values: new object[,]
                {
                    { 1, "Test Content for first comment", new DateTime(2024, 2, 3, 22, 55, 47, 728, DateTimeKind.Local).AddTicks(540), 1, "First Comment Title" },
                    { 2, "Test Content for second comment", new DateTime(2024, 2, 3, 22, 55, 47, 728, DateTimeKind.Local).AddTicks(542), 2, "Second Comment Title" }
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
        }
    }
}
