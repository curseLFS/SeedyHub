using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeedyHub.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalQuantity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfTransaction = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Items_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Suffix = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Accepted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberId);
                    table.ForeignKey(
                        name: "FK_Members_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Fruits" },
                    { 2, "Frozen Goods" },
                    { 3, "Vegetables" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Regular" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "CategoryId", "DateOfTransaction", "Description", "Image", "ItemName", "Price", "Quantity", "TotalPrice", "TotalQuantity" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 5, 12, 18, 22, 22, 107, DateTimeKind.Local).AddTicks(977), "The mango fruit is roughly oval in shape, with uneven sides. The fruit is a drupe, with an outer flesh surrounding a stone. The flesh is soft and bright yellow-orange in color. The skin of the fruit is yellow-green to red. Mango trees can grow to a height of 45 m (148 ft) and can live for in excess of 100 years.", "", "Mango", 60.0, 30, 1800.0, 30 },
                    { 2, 2, new DateTime(2022, 5, 12, 18, 22, 22, 107, DateTimeKind.Local).AddTicks(979), "French fries are served hot, either soft or crispy, and are generally eaten as part of lunch or dinner or by themselves as a snack, and they commonly appear on the menus of diners, fast food restaurants, pubs, and bars.", "", "Fries", 120.0, 50, 6000.0, 50 },
                    { 3, 3, new DateTime(2022, 5, 12, 18, 22, 22, 107, DateTimeKind.Local).AddTicks(980), "Filipino eggplants, botanically classified as Solanum melongena, are cultivated in the Philippines and are a member of the Solanaceae, or nightshade family. Similar to the Chinese eggplant and Japanese eggplant, these fruits are known for their sweet flavor, very few seeds, and meaty texture", "", "Talong", 20.0, 10, 200.0, 20 }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "Accepted", "Birthday", "FirstName", "Image", "LastName", "RoleId", "Suffix" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 5, 12, 18, 22, 22, 107, DateTimeKind.Local).AddTicks(962), new DateTime(2022, 5, 12, 18, 22, 22, 107, DateTimeKind.Local).AddTicks(960), "Jeoganni", "", "Canda", 1, "Jr" },
                    { 2, new DateTime(2022, 5, 12, 18, 22, 22, 107, DateTimeKind.Local).AddTicks(965), new DateTime(2022, 5, 12, 18, 22, 22, 107, DateTimeKind.Local).AddTicks(964), "Juncel", "", "Diaz", 2, "" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoryId",
                table: "Items",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_RoleId",
                table: "Members",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
