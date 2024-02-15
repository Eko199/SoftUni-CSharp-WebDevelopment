using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b7e5373f-613f-469f-8702-9a62001112ba", 0, "9e9245ea-ee0e-465b-adea-58bbf93c72c1", null, false, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAEAACcQAAAAENk1paUQD2SzBueTTmKTgsWaBaOB3prouQRmGB4V0OjCwjZDGhq0tz6dGHArmsYTYw==", null, false, "b65a6efa-2218-4fe2-8bbb-e30cb0bb5b7f", false, "test@softuni.bg" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "In Progress" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 7, 30, 15, 9, 42, 854, DateTimeKind.Local).AddTicks(8190), "Implement better styling for all public pages", "b7e5373f-613f-469f-8702-9a62001112ba", "Improve CSS styles" },
                    { 2, 1, new DateTime(2023, 9, 15, 15, 9, 42, 854, DateTimeKind.Local).AddTicks(8227), "Create Android client app fot the TaskBoard RESTful API", "b7e5373f-613f-469f-8702-9a62001112ba", "Android Client App" },
                    { 3, 2, new DateTime(2024, 1, 15, 15, 9, 42, 854, DateTimeKind.Local).AddTicks(8231), "Create Windows Forms desktop app client fot the TaskBoard RESTful API", "b7e5373f-613f-469f-8702-9a62001112ba", "Desktop Client App" },
                    { 4, 3, new DateTime(2023, 2, 15, 15, 9, 42, 854, DateTimeKind.Local).AddTicks(8234), "Implement [Create Task] page for adding new tasks", "b7e5373f-613f-469f-8702-9a62001112ba", "Create Tasks" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b7e5373f-613f-469f-8702-9a62001112ba");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
