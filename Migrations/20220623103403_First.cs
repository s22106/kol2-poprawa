using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kol2poprawa_ko_s22106.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    organizationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    organizationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    organizationDomain = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.organizationID);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    memberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    organizationId = table.Column<int>(type: "int", nullable: false),
                    memberName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    memberSurname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    memberNickname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.memberId);
                    table.ForeignKey(
                        name: "FK_Member_Organization_organizationId",
                        column: x => x.organizationId,
                        principalTable: "Organization",
                        principalColumn: "organizationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    teamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    organizationId = table.Column<int>(type: "int", nullable: false),
                    teamName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.teamId);
                    table.ForeignKey(
                        name: "FK_Team_Organization_organizationId",
                        column: x => x.organizationId,
                        principalTable: "Organization",
                        principalColumn: "organizationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    fileId = table.Column<int>(type: "int", nullable: false),
                    teamId = table.Column<int>(type: "int", nullable: false),
                    fileName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    fileExtension = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    fileSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => new { x.fileId, x.teamId });
                    table.ForeignKey(
                        name: "FK_File_Team_teamId",
                        column: x => x.teamId,
                        principalTable: "Team",
                        principalColumn: "teamId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Membership",
                columns: table => new
                {
                    memberId = table.Column<int>(type: "int", nullable: false),
                    teamId = table.Column<int>(type: "int", nullable: false),
                    membershipDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membership", x => new { x.memberId, x.teamId });
                    table.ForeignKey(
                        name: "FK_Membership_Member_memberId",
                        column: x => x.memberId,
                        principalTable: "Member",
                        principalColumn: "memberId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Membership_Team_teamId",
                        column: x => x.teamId,
                        principalTable: "Team",
                        principalColumn: "teamId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Organization",
                columns: new[] { "organizationID", "organizationDomain", "organizationName" },
                values: new object[] { 1, "domain", "org1" });

            migrationBuilder.InsertData(
                table: "Member",
                columns: new[] { "memberId", "memberName", "memberNickname", "memberSurname", "organizationId" },
                values: new object[] { 1, "name", "nickname", "surname", 1 });

            migrationBuilder.InsertData(
                table: "Team",
                columns: new[] { "teamId", "description", "organizationId", "teamName" },
                values: new object[] { 1, "description", 1, "team1" });

            migrationBuilder.InsertData(
                table: "File",
                columns: new[] { "fileId", "teamId", "fileExtension", "fileName", "fileSize" },
                values: new object[] { 1, 1, "ext", "name", 16 });

            migrationBuilder.InsertData(
                table: "Membership",
                columns: new[] { "memberId", "teamId", "membershipDate" },
                values: new object[] { 1, 1, new DateTime(2022, 6, 23, 12, 34, 2, 815, DateTimeKind.Local).AddTicks(3750) });

            migrationBuilder.CreateIndex(
                name: "IX_File_teamId",
                table: "File",
                column: "teamId");

            migrationBuilder.CreateIndex(
                name: "IX_Member_organizationId",
                table: "Member",
                column: "organizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Membership_teamId",
                table: "Membership",
                column: "teamId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_organizationId",
                table: "Team",
                column: "organizationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropTable(
                name: "Membership");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Organization");
        }
    }
}
