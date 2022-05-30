using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smedix.RecruitmentFunnel.Migrations
{
    public partial class CanidateIdcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateHistories_Candidates_candidateId",
                table: "CandidateHistories");

            migrationBuilder.RenameColumn(
                name: "candidateId",
                table: "CandidateHistories",
                newName: "CandidateId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateHistories_candidateId",
                table: "CandidateHistories",
                newName: "IX_CandidateHistories_CandidateId");

            migrationBuilder.AlterColumn<int>(
                name: "CandidateId",
                table: "CandidateHistories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateHistories_Candidates_CandidateId",
                table: "CandidateHistories",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateHistories_Candidates_CandidateId",
                table: "CandidateHistories");

            migrationBuilder.RenameColumn(
                name: "CandidateId",
                table: "CandidateHistories",
                newName: "candidateId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateHistories_CandidateId",
                table: "CandidateHistories",
                newName: "IX_CandidateHistories_candidateId");

            migrationBuilder.AlterColumn<int>(
                name: "candidateId",
                table: "CandidateHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateHistories_Candidates_candidateId",
                table: "CandidateHistories",
                column: "candidateId",
                principalTable: "Candidates",
                principalColumn: "Id");
        }
    }
}
