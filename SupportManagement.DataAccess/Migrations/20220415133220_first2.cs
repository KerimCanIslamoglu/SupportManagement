using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SupportManagement.DataAccess.Migrations
{
    public partial class first2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Seniorities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeniorityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Multiplier = table.Column<double>(type: "float", nullable: false),
                    AssignmentOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seniorities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShiftStarts = table.Column<TimeSpan>(type: "time", nullable: false),
                    ShiftEnds = table.Column<TimeSpan>(type: "time", nullable: false),
                    IsOverflowTeam = table.Column<bool>(type: "bit", nullable: false),
                    WorksInOfficeHours = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    SeniorityId = table.Column<int>(type: "int", nullable: false),
                    QueueName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamMembers_Seniorities_SeniorityId",
                        column: x => x.SeniorityId,
                        principalTable: "Seniorities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamMembers_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TeamMemberId = table.Column<int>(type: "int", nullable: false),
                    SentOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chats_TeamMembers_TeamMemberId",
                        column: x => x.TeamMemberId,
                        principalTable: "TeamMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chats_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Seniorities",
                columns: new[] { "Id", "AssignmentOrder", "Multiplier", "SeniorityName" },
                values: new object[,]
                {
                    { 1, 1, 0.40000000000000002, "Junior" },
                    { 2, 2, 0.59999999999999998, "Mid-Level" },
                    { 3, 3, 0.80000000000000004, "Senior" },
                    { 4, 4, 0.5, "Team Lead" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "IsOverflowTeam", "ShiftEnds", "ShiftStarts", "TeamName", "WorksInOfficeHours" },
                values: new object[,]
                {
                    { 1, false, new TimeSpan(0, 15, 59, 59, 0), new TimeSpan(0, 8, 0, 0, 0), "Team A", true },
                    { 2, false, new TimeSpan(0, 23, 59, 59, 0), new TimeSpan(0, 16, 0, 0, 0), "Team B", false },
                    { 3, false, new TimeSpan(0, 7, 59, 59, 0), new TimeSpan(0, 0, 0, 0, 0), "Team C", false },
                    { 4, true, new TimeSpan(0, 23, 59, 59, 0), new TimeSpan(0, 0, 0, 0, 0), "Overflow Team", true }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "UserName" },
                values: new object[] { 1, "User 1" });

            migrationBuilder.InsertData(
                table: "TeamMembers",
                columns: new[] { "Id", "QueueName", "SeniorityId", "TeamId" },
                values: new object[,]
                {
                    { 1, "member_1", 4, 1 },
                    { 2, "member_2", 2, 1 },
                    { 3, "member_3", 2, 1 },
                    { 4, "member_4", 1, 1 },
                    { 5, "member_5", 3, 2 },
                    { 6, "member_6", 2, 2 },
                    { 7, "member_7", 1, 2 },
                    { 8, "member_8", 1, 2 },
                    { 9, "member_9", 2, 3 },
                    { 10, "member_10", 2, 3 },
                    { 11, "member_11", 1, 4 },
                    { 12, "member_12", 1, 4 },
                    { 13, "member_13", 1, 4 },
                    { 14, "member_14", 1, 4 },
                    { 15, "member_15", 1, 4 },
                    { 16, "member_16", 1, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chats_TeamMemberId",
                table: "Chats",
                column: "TeamMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_UserId",
                table: "Chats",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_SeniorityId",
                table: "TeamMembers",
                column: "SeniorityId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_TeamId",
                table: "TeamMembers",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "TeamMembers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Seniorities");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
