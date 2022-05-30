using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smedix.RecruitmentFunnel.Migrations
{
    public partial class properhistorystepstatuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "StageStatuses",
                columns: new[] { "Id", "StageId", "StatusId" },
                values: new object[,]
                {
                    { 9, 5, 1 },
                    { 10, 5, 3 },
                    { 11, 5, 7 },
                    { 12, 6, 2 },
                    { 13, 6, 9 },
                    { 14, 6, 8 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StageStatuses",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "StageStatuses",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "StageStatuses",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "StageStatuses",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "StageStatuses",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "StageStatuses",
                keyColumn: "Id",
                keyValue: 14);
        }
    }
}
