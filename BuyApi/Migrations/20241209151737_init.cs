using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BuyApi.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buy",
                columns: table => new
                {
                    BuyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    StatusTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoOfItems = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderPlacedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Orderid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buy", x => x.BuyId);
                });

            migrationBuilder.CreateTable(
                name: "CouponCodes",
                columns: table => new
                {
                    CouponId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Couponcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsApplicable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouponCodes", x => x.CouponId);
                });

            migrationBuilder.InsertData(
                table: "CouponCodes",
                columns: new[] { "CouponId", "Couponcode", "IsApplicable", "description" },
                values: new object[,]
                {
                    { 1, "SHOPEASE20", true, "Flat $20 off on minimum purchase of $50 and Free shipping." },
                    { 2, "SUMMERSALE", false, "Flat 25% off on summer collection." },
                    { 3, "FREESHIP", true, "Free shipping on orders over $50" },
                    { 4, "SAVE10", true, "Flat $10 off on your first purchase (min purchase of $50)." },
                    { 5, "BUY2GET50OFF", true, "Buy 2, Get 50% Off on the 3rd One." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buy");

            migrationBuilder.DropTable(
                name: "CouponCodes");
        }
    }
}
