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
                    ItemAmount = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemPar = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                });

            migrationBuilder.CreateTable(
                name: "Livestocks",
                columns: table => new
                {
                    LivestockId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LivestockTag = table.Column<string>(type: "TEXT", nullable: true),
                    LivestockName = table.Column<string>(type: "TEXT", nullable: true),
                    LivestockType = table.Column<string>(type: "TEXT", nullable: true),
                    LivestockBreed = table.Column<string>(type: "TEXT", nullable: true),
                    LivestockDob = table.Column<string>(type: "TEXT", nullable: true),
                    LivestockDos = table.Column<string>(type: "TEXT", nullable: true),
                    LivestockComments = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livestocks", x => x.LivestockId);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "ItemAmount", "ItemName", "ItemPar" },
                values: new object[,]
                {
                    { new Guid("4bb37e1b-aeab-4dc0-970e-87b30efb6093"), 12, "Unleaded Fuel", 10 },
                    { new Guid("6a41daee-22ef-47a1-b269-40ef111afe79"), 6, "Hay", 10 },
                    { new Guid("b31ac87e-0a50-41c0-910e-f305ebfcca88"), 25, "Diesel Fuel", 10 }
                });

            migrationBuilder.InsertData(
                table: "Livestocks",
                columns: new[] { "LivestockId", "LivestockBreed", "LivestockComments", "LivestockDob", "LivestockDos", "LivestockName", "LivestockTag", "LivestockType" },
                values: new object[,]
                {
                    { new Guid("786e921d-8aae-4f82-9270-5251a6f1c685"), "Black Angus", "Rambo is used to help rear new calves.", "Unknown", "n/a", "Rambo", null, "Mentor Animal" },
                    { new Guid("b46263f4-c750-459c-95c2-7ae362e15382"), "Black Angus", null, "2019", "TBD", "Gimpy", null, "Meat Steer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Livestocks");
        }
    }
}
