using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HouseRentingSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserClaims : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: ["Id", "ClaimType", "ClaimValue", "UserId"],
                values: new object[,]
                {
                    { 2, "user:fullname", "Linda Michaels", "dea12856-c198-4129-b3f3-b893d8395082" },
                    { 3, "user:fullname", "Teodor Lesly", "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" },
                    { 4, "user:fullname", "Great Admin", "bcb4f072-ecca-43c9-ab26-c060c6f364e4" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
