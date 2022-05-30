using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smedix.RecruitmentFunnel.Migrations
{
    public partial class fixedtechnicalinterviewstatuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StageStatuses",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "StageStatuses",
                keyColumn: "Id",
                keyValue: 8,
                column: "StatusId",
                value: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StageStatuses",
                keyColumn: "Id",
                keyValue: 8,
                column: "StatusId",
                value: 3);

            migrationBuilder.InsertData(
                table: "StageStatuses",
                columns: new[] { "Id", "StageId", "StatusId" },
                values: new object[] { 9, 4, 7 });
        }
    }
}
