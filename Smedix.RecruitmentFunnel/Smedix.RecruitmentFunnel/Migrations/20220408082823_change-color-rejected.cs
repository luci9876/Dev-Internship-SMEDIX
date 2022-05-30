using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smedix.RecruitmentFunnel.Migrations
{
    public partial class changecolorrejected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CandidateStatuses",
                keyColumn: "Id",
                keyValue: 8,
                column: "ColorHex",
                value: "#F50A0A");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CandidateStatuses",
                keyColumn: "Id",
                keyValue: 8,
                column: "ColorHex",
                value: "#FFFFFF");
        }
    }
}
