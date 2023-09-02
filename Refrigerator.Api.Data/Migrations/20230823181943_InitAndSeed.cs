using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Refrigerator.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitAndSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FridgeActivityLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ActivityDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FridgeActivityLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FridgeActivityLogs_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsExpired = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stocks_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BaseUnit", "ExpirationDate", "Name" },
                values: new object[,]
                {
                    { 1, "Millilitre", new DateTime(2023, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Milk" },
                    { 2, "Millilitre", new DateTime(2023, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Apple Juice" },
                    { 3, "Gram", new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Apple" },
                    { 4, "Number", new DateTime(2023, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Banana" },
                    { 5, "Gram", new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Orange" },
                    { 6, "Gram", new DateTime(2023, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ice Cream" },
                    { 7, "Millilitre", new DateTime(2023, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mixed Juice" },
                    { 8, "Gram", new DateTime(2023, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bread" },
                    { 9, "Number", new DateTime(2023, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Egg" },
                    { 10, "Number", new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Donuts" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FridgeActivityLogs_ProductId",
                table: "FridgeActivityLogs",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductId",
                table: "Stocks",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FridgeActivityLogs");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
