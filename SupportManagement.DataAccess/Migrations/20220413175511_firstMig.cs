using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SupportManagement.DataAccess.Migrations
{
    public partial class firstMig : Migration
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
                    IsOverflowTeam = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    SeniorityId = table.Column<int>(type: "int", nullable: false)
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
                columns: new[] { "Id", "IsOverflowTeam", "ShiftEnds", "ShiftStarts", "TeamName" },
                values: new object[,]
                {
                    { 1, false, new TimeSpan(0, 15, 59, 59, 0), new TimeSpan(0, 8, 0, 0, 0), "Team A" },
                    { 2, false, new TimeSpan(0, 23, 59, 59, 0), new TimeSpan(0, 16, 0, 0, 0), "Team B" },
                    { 3, false, new TimeSpan(0, 7, 59, 59, 0), new TimeSpan(0, 0, 0, 0, 0), "Team C" },
                    { 4, true, new TimeSpan(0, 23, 59, 59, 0), new TimeSpan(0, 0, 0, 0, 0), "Overflow Team" }
                });

            migrationBuilder.InsertData(
                table: "TeamMembers",
                columns: new[] { "Id", "SeniorityId", "TeamId" },
                values: new object[,]
                {
                    { 1, 4, 1 },
                    { 5, 3, 2 },
                    { 10, 2, 3 },
                    { 16, 1, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_SeniorityId",
                table: "TeamMembers",
                column: "SeniorityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_TeamId",
                table: "TeamMembers",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamMembers");

            migrationBuilder.DropTable(
                name: "Seniorities");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
