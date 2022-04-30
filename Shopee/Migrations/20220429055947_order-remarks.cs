using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopee.Migrations
{
    public partial class orderremarks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("016c0f7c-b210-4022-944d-0a3822c344f0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("17ece5d4-1a21-4d0a-bbc2-55dbb4c1a328"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("242caee3-3892-4b7c-8489-e30df33224eb"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("57193e6b-6360-4034-b0bf-259fd10c3456"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("68d1739e-a840-433a-bd2f-c0dc6a45479e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b9eeaba8-42a1-42b7-85d3-df8040b0f0f3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b870f153-7518-4bbd-af40-7ad6d5f25f23"));

            migrationBuilder.CreateTable(
                name: "Remarks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ByUserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TimeStamp = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Text = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrderId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Remarks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Remarks_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Remarks_Users_ByUserId",
                        column: x => x.ByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Category", "ParentId" },
                values: new object[,]
                {
                    { new Guid("63dd5bea-9cbe-41d4-9618-0779365f3407"), "Mobile", null },
                    { new Guid("8f762efe-cd48-4168-b1fd-74be1daf40a9"), "Household", null },
                    { new Guid("910b81bd-57a4-400f-b2a9-b2cf24770f88"), "Electronics", null },
                    { new Guid("91944e73-03c3-4f80-86a0-2d1437b31ad7"), "Fession", null },
                    { new Guid("c30288b6-105e-4250-baf8-b63f3d25a050"), "TV", null },
                    { new Guid("fd3ea37a-0c6d-41c4-a0db-2cf89c9a8331"), "All", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ContactNumber", "Email", "FirstName", "IsAdmin", "LastName", "Location", "Password", "Username" },
                values: new object[] { new Guid("53b05145-8975-48bb-b88e-a8d99cd33138"), "0000000", "admin@local.com", "Admin", true, "", "Office", "admin", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Remarks_ByUserId",
                table: "Remarks",
                column: "ByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Remarks_OrderId",
                table: "Remarks",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Remarks");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("63dd5bea-9cbe-41d4-9618-0779365f3407"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8f762efe-cd48-4168-b1fd-74be1daf40a9"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("910b81bd-57a4-400f-b2a9-b2cf24770f88"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("91944e73-03c3-4f80-86a0-2d1437b31ad7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c30288b6-105e-4250-baf8-b63f3d25a050"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fd3ea37a-0c6d-41c4-a0db-2cf89c9a8331"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("53b05145-8975-48bb-b88e-a8d99cd33138"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Category", "ParentId" },
                values: new object[,]
                {
                    { new Guid("016c0f7c-b210-4022-944d-0a3822c344f0"), "Mobile", null },
                    { new Guid("17ece5d4-1a21-4d0a-bbc2-55dbb4c1a328"), "Household", null },
                    { new Guid("242caee3-3892-4b7c-8489-e30df33224eb"), "Electronics", null },
                    { new Guid("57193e6b-6360-4034-b0bf-259fd10c3456"), "All", null },
                    { new Guid("68d1739e-a840-433a-bd2f-c0dc6a45479e"), "Fession", null },
                    { new Guid("b9eeaba8-42a1-42b7-85d3-df8040b0f0f3"), "TV", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ContactNumber", "Email", "FirstName", "IsActive", "IsAdmin", "LastName", "Location", "Password", "Username" },
                values: new object[] { new Guid("b870f153-7518-4bbd-af40-7ad6d5f25f23"), "0000000", "admin@local.com", "Admin", false, true, "", "Office", "admin", "admin" });
        }
    }
}
