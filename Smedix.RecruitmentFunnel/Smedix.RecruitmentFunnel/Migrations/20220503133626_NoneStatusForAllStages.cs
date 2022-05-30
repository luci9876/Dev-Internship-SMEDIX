using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smedix.RecruitmentFunnel.Migrations
{
    public partial class NoneStatusForAllStages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Name" },
                values: new object[] { 10, "None" });

            migrationBuilder.InsertData(
                table: "StageStatuses",
                columns: new[] { "Id", "StageId", "StatusId" },
                values: new object[,]
                {
                    { 15, 1, 10 },
                    { 16, 2, 10 },
                    { 17, 3, 10 },
                    { 18, 4, 10 },
                    { 19, 5, 10 },
                    { 20, 6, 10 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StageStatuses",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "StageStatuses",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "StageStatuses",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "StageStatuses",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "StageStatuses",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "StageStatuses",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
