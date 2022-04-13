using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SupportManagement.DataAccess.Migrations
{
    public partial class addedchat2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SentOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.InsertData(
                table: "TeamMembers",
                columns: new[] { "Id", "SeniorityId", "TeamId" },
                values: new object[,]
                {
                    { 15, 1, 4 },
                    { 14, 1, 4 },
                    { 13, 1, 4 },
                    { 12, 1, 4 },
                    { 11, 1, 4 },
                    { 9, 2, 3 },
                    { 8, 1, 2 },
                    { 7, 1, 2 },
                    { 6, 2, 2 },
                    { 4, 1, 1 },
                    { 3, 2, 1 },
                    { 2, 2, 1 }
                });
        }
    }
}
