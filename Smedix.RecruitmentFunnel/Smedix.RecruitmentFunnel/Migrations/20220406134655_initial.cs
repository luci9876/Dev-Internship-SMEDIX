using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smedix.RecruitmentFunnel.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CandidateStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColorHex = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Technologies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technologies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearsOfExperience = table.Column<int>(type: "int", nullable: true),
                    LinkedIn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferredBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    CandidateStatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Candidates_CandidateStatuses_CandidateStatusId",
                        column: x => x.CandidateStatusId,
                        principalTable: "CandidateStatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Candidates_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Candidates_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StageStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StageId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StageStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StageStatuses_Stages_StageId",
                        column: x => x.StageId,
                        principalTable: "Stages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StageStatuses_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateFiles_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateTechnologies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TechnologyId = table.Column<int>(type: "int", nullable: false),
                    CandidateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateTechnologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateTechnologies_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateTechnologies_Technologies_TechnologyId",
                        column: x => x.TechnologyId,
                        principalTable: "Technologies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntryDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlannedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manager = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Issuer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CandidateId = table.Column<int>(type: "int", nullable: false),
                    StageStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateHistories_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateHistories_StageStatuses_StageStatusId",
                        column: x => x.StageStatusId,
                        principalTable: "StageStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CandidateStatuses",
                columns: new[] { "Id", "ColorHex", "Name" },
                values: new object[,]
                {
                    { 1, "#3655B3", "Applied" },
                    { 2, "#800080", "Contacted" },
                    { 3, "#5A0049", "Recontacted" },
                    { 4, "#F07443", "Uncontacted" },
                    { 5, "#008000", "Hired" },
                    { 6, "#E04DB0", "In process" },
                    { 7, "#B30000", "Blacklist" },
                    { 8, "#FFFFFF", "Rejected" },
                    { 9, "#595260", "Not Interested" },
                    { 10, "#444444", "Decline Offer" },
                    { 11, "#6D8299", "Withdrew" },
                    { 12, "#DAAB05", "Keep in mind" },
                    { 13, "#0B4619", "Former employee" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Administrative" },
                    { 2, "Bioinformatics" },
                    { 3, "Development" },
                    { 4, "HR" },
                    { 5, "IT" },
                    { 6, "Management" },
                    { 7, "Requirements" },
                    { 8, "Testing" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Software Tester Manual" },
                    { 2, "Software Tester Automation" },
                    { 3, "Software Tester" },
                    { 4, "System Tester" },
                    { 5, "Software Developer" },
                    { 6, "Business Analyst" },
                    { 7, "Requirements Analyst" },
                    { 8, "Product Owner" },
                    { 9, "Scrum Master" },
                    { 10, "Project Manager" },
                    { 11, "Delivery Manager" },
                    { 12, "Director" },
                    { 13, "QA Architect" },
                    { 14, "Development Architect" },
                    { 15, "DevOps" },
                    { 16, "Sys Admin" },
                    { 17, "Recruiter" },
                    { 18, "HR Specialist" },
                    { 19, "Business Development Manager" }
                });

            migrationBuilder.InsertData(
                table: "Stages",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sourced" },
                    { 2, "Contacted" }
                });

            migrationBuilder.InsertData(
                table: "Stages",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 3, "HR Interview" },
                    { 4, "Technical Interview" },
                    { 5, "Offer" },
                    { 6, "Final Status" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Accepted" },
                    { 2, "Rejected" },
                    { 3, "Declined" },
                    { 4, "Not Interested" },
                    { 5, "Review in 6 months" },
                    { 6, "No Answer" },
                    { 7, "Renegotiated" },
                    { 8, "Feedback sent" },
                    { 9, "Hired" }
                });

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, ".NET" },
                    { 2, "Javascript" },
                    { 3, "Full Stack" },
                    { 4, "QA Automation" },
                    { 5, "QA" },
                    { 6, "DevOps" },
                    { 7, "Sys Administraton" },
                    { 8, "Delphi" },
                    { 9, "Requirements" },
                    { 10, "LabVIEW" },
                    { 11, "Front end" },
                    { 12, "Back end" },
                    { 13, "Recruitment" },
                    { 14, "Administration" },
                    { 15, "Python" },
                    { 16, "Product Owner" },
                    { 17, "Management" },
                    { 18, "Java" },
                    { 19, "PHP" },
                    { 20, "Embedded C/C++" },
                    { 21, "Embedded C" },
                    { 22, "C++" },
                    { 23, "Angular" },
                    { 24, "Angular JS" },
                    { 25, "React JS" },
                    { 26, "Node JS" },
                    { 27, "Cybersecurity" }
                });

            migrationBuilder.InsertData(
                table: "StageStatuses",
                columns: new[] { "Id", "StageId", "StatusId" },
                values: new object[,]
                {
                    { 1, 2, 1 },
                    { 2, 2, 4 },
                    { 3, 2, 5 },
                    { 4, 2, 6 },
                    { 5, 3, 1 },
                    { 6, 3, 2 },
                    { 7, 4, 1 },
                    { 8, 4, 3 },
                    { 9, 4, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateFiles_CandidateId",
                table: "CandidateFiles",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateHistories_CandidateId",
                table: "CandidateHistories",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateHistories_StageStatusId",
                table: "CandidateHistories",
                column: "StageStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_CandidateStatusId",
                table: "Candidates",
                column: "CandidateStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_DepartmentId",
                table: "Candidates",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_RoleId",
                table: "Candidates",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateTechnologies_CandidateId",
                table: "CandidateTechnologies",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateTechnologies_TechnologyId",
                table: "CandidateTechnologies",
                column: "TechnologyId");

            migrationBuilder.CreateIndex(
                name: "IX_StageStatuses_StageId",
                table: "StageStatuses",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_StageStatuses_StatusId",
                table: "StageStatuses",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateFiles");

            migrationBuilder.DropTable(
                name: "CandidateHistories");

            migrationBuilder.DropTable(
                name: "CandidateTechnologies");

            migrationBuilder.DropTable(
                name: "StageStatuses");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "Technologies");

            migrationBuilder.DropTable(
                name: "Stages");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "CandidateStatuses");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
