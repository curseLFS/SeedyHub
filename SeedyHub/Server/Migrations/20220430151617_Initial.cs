using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeedyHub.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "members",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Accepted = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_members", x => x.MemberId);
                    table.ForeignKey(
                        name: "FK_members_roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { 1, "Admin" });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[] { 2, "Regular" });

            migrationBuilder.InsertData(
                table: "members",
                columns: new[] { "MemberId", "Accepted", "FirstName", "LastName", "RoleId" },
                values: new object[] { 1, "04/30/2022", "Jeoganni", "Canda", 1 });

            migrationBuilder.InsertData(
                table: "members",
                columns: new[] { "MemberId", "Accepted", "FirstName", "LastName", "RoleId" },
                values: new object[] { 2, "04/30/2022", "Juncel", "Diaz", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_members_RoleId",
                table: "members",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "members");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
