using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InventorySystem.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ItemName = table.Column<string>(type: "TEXT", nullable: true),
                    ItemAmt = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemPar = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "ItemAmt", "ItemName", "ItemPar" },
                values: new object[,]
                {
                    { new Guid("01a7c6f6-0cb8-45e7-8ec6-7195623fc7ab"), 12, "Unleaded Fuel", 10 },
                    { new Guid("91d454b1-1a73-4405-a202-a5aa784804e4"), 25, "Diesel Fuel", 10 },
                    { new Guid("d9a9b282-30c0-4e73-9c94-53afd8944143"), 6, "Hay", 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
