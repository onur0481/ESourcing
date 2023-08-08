using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrderService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ORDER");

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "ORDER",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuctionID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SellerUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                });

            migrationBuilder.InsertData(
                schema: "ORDER",
                table: "Orders",
                columns: new[] { "ID", "AuctionID", "CreatedDate", "ProductID", "SellerUserName", "TotalPrice", "UnitPrice" },
                values: new object[,]
                {
                    { 1, "0041ff6a-6f3c-4c05-908c-43c90e2b877d", new DateTime(2023, 7, 30, 20, 20, 9, 965, DateTimeKind.Local).AddTicks(8964), "4f43ef6d-e53d-44a1-a79e-a92f469e9b56", "test@test.com", 1000m, 10m },
                    { 2, "5b85c4d7-7c61-4f25-9eb3-13c5275a86f8", new DateTime(2023, 7, 30, 20, 20, 9, 965, DateTimeKind.Local).AddTicks(8980), "e0c0436b-6982-49f0-8277-4a73b79c9093", "test@test.com", 1000m, 10m },
                    { 3, "3dcdc910-5abf-438e-b269-6923236e247d", new DateTime(2023, 7, 30, 20, 20, 9, 965, DateTimeKind.Local).AddTicks(8984), "bc29ed43-c53f-49f3-9a76-e4725a5042d2", "test@test.com", 1000m, 10m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders",
                schema: "ORDER");
        }
    }
}
