using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AdminDashboard.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "Name", "Price", "StockQuantity" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mechanical Keyboard", 99.99m, 45 },
                    { 2, new DateTime(2026, 9, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Gaming Mouse", 49.50m, 80 },
                    { 3, new DateTime(2026, 9, 10, 0, 0, 0, 0, DateTimeKind.Utc), "UltraWide Monitor", 399.00m, 12 },
                    { 4, new DateTime(2026, 9, 15, 0, 0, 0, 0, DateTimeKind.Utc), "USB-C Dock", 129.99m, 25 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
