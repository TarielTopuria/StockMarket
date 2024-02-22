using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class seedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2f56e6f1-3c05-4f31-9e7e-db59b281fb1f", null, "Client", "CLIENT" },
                    { "49536326-e934-46f6-bb75-7df43a13e669", null, "Manager", "MANAGER" },
                    { "5244b7a3-7f42-4807-8bf7-daf980557964", null, "Admin", "ADMIN" },
                    { "dcf73c32-4c12-48d2-9f00-1d4c20d47b8c", null, "Operator", "OPERATOR" }
                });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2024, 2, 22, 22, 18, 31, 69, DateTimeKind.Local).AddTicks(597));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2024, 2, 22, 22, 18, 31, 69, DateTimeKind.Local).AddTicks(599));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2024, 2, 22, 22, 18, 31, 69, DateTimeKind.Local).AddTicks(601));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationTime",
                value: new DateTime(2024, 2, 22, 22, 18, 31, 69, DateTimeKind.Local).AddTicks(602));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationTime",
                value: new DateTime(2024, 2, 22, 22, 18, 31, 69, DateTimeKind.Local).AddTicks(604));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationTime",
                value: new DateTime(2024, 2, 22, 22, 18, 31, 69, DateTimeKind.Local).AddTicks(605));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationTime",
                value: new DateTime(2024, 2, 22, 22, 18, 31, 69, DateTimeKind.Local).AddTicks(606));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreationTime",
                value: new DateTime(2024, 2, 22, 22, 18, 31, 69, DateTimeKind.Local).AddTicks(608));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreationTime",
                value: new DateTime(2024, 2, 22, 22, 18, 31, 69, DateTimeKind.Local).AddTicks(609));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreationTime",
                value: new DateTime(2024, 2, 22, 22, 18, 31, 69, DateTimeKind.Local).AddTicks(610));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreationTime",
                value: new DateTime(2024, 2, 22, 22, 18, 31, 69, DateTimeKind.Local).AddTicks(612));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f56e6f1-3c05-4f31-9e7e-db59b281fb1f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49536326-e934-46f6-bb75-7df43a13e669");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5244b7a3-7f42-4807-8bf7-daf980557964");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dcf73c32-4c12-48d2-9f00-1d4c20d47b8c");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2024, 2, 21, 21, 54, 49, 539, DateTimeKind.Local).AddTicks(6831));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2024, 2, 21, 21, 54, 49, 539, DateTimeKind.Local).AddTicks(6834));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2024, 2, 21, 21, 54, 49, 539, DateTimeKind.Local).AddTicks(6835));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationTime",
                value: new DateTime(2024, 2, 21, 21, 54, 49, 539, DateTimeKind.Local).AddTicks(6837));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationTime",
                value: new DateTime(2024, 2, 21, 21, 54, 49, 539, DateTimeKind.Local).AddTicks(6838));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationTime",
                value: new DateTime(2024, 2, 21, 21, 54, 49, 539, DateTimeKind.Local).AddTicks(6840));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationTime",
                value: new DateTime(2024, 2, 21, 21, 54, 49, 539, DateTimeKind.Local).AddTicks(6842));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreationTime",
                value: new DateTime(2024, 2, 21, 21, 54, 49, 539, DateTimeKind.Local).AddTicks(6843));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreationTime",
                value: new DateTime(2024, 2, 21, 21, 54, 49, 539, DateTimeKind.Local).AddTicks(6845));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreationTime",
                value: new DateTime(2024, 2, 21, 21, 54, 49, 539, DateTimeKind.Local).AddTicks(6846));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreationTime",
                value: new DateTime(2024, 2, 21, 21, 54, 49, 539, DateTimeKind.Local).AddTicks(6848));
        }
    }
}
