using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kol2poprawa_ko_s22106.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Member",
                columns: new[] { "memberId", "memberName", "memberNickname", "memberSurname", "organizationId" },
                values: new object[] { 2, "name2", "nickname2", "surname2", 1 });

            migrationBuilder.UpdateData(
                table: "Membership",
                keyColumns: new[] { "memberId", "teamId" },
                keyValues: new object[] { 1, 1 },
                column: "membershipDate",
                value: new DateTime(2022, 6, 23, 12, 38, 32, 824, DateTimeKind.Local).AddTicks(5810));

            migrationBuilder.InsertData(
                table: "Organization",
                columns: new[] { "organizationID", "organizationDomain", "organizationName" },
                values: new object[] { 2, "domain2", "org2" });

            migrationBuilder.InsertData(
                table: "Member",
                columns: new[] { "memberId", "memberName", "memberNickname", "memberSurname", "organizationId" },
                values: new object[] { 3, "name3", "nickname3", "surname3", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Member",
                keyColumn: "memberId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Member",
                keyColumn: "memberId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Organization",
                keyColumn: "organizationID",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Membership",
                keyColumns: new[] { "memberId", "teamId" },
                keyValues: new object[] { 1, 1 },
                column: "membershipDate",
                value: new DateTime(2022, 6, 23, 12, 34, 2, 815, DateTimeKind.Local).AddTicks(3750));
        }
    }
}
