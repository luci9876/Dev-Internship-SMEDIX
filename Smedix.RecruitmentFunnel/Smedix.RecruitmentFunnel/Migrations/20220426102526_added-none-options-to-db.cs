using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smedix.RecruitmentFunnel.Migrations
{
    public partial class addednoneoptionstodb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CandidateStatuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ColorHex", "Name" },
                values: new object[] { "#40E0D0", "Select..." });

            migrationBuilder.UpdateData(
                table: "CandidateStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ColorHex", "Name" },
                values: new object[] { "#3655B3", "Applied" });

            migrationBuilder.UpdateData(
                table: "CandidateStatuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ColorHex", "Name" },
                values: new object[] { "#800080", "Contacted" });

            migrationBuilder.UpdateData(
                table: "CandidateStatuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ColorHex", "Name" },
                values: new object[] { "#5A0049", "Recontacted" });

            migrationBuilder.UpdateData(
                table: "CandidateStatuses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ColorHex", "Name" },
                values: new object[] { "#F07443", "Uncontacted" });

            migrationBuilder.UpdateData(
                table: "CandidateStatuses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ColorHex", "Name" },
                values: new object[] { "#008000", "Hired" });

            migrationBuilder.UpdateData(
                table: "CandidateStatuses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ColorHex", "Name" },
                values: new object[] { "#E04DB0", "In process" });

            migrationBuilder.UpdateData(
                table: "CandidateStatuses",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ColorHex", "Name" },
                values: new object[] { "#B30000", "Blacklist" });

            migrationBuilder.UpdateData(
                table: "CandidateStatuses",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ColorHex", "Name" },
                values: new object[] { "#F50A0A", "Rejected" });

            migrationBuilder.UpdateData(
                table: "CandidateStatuses",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ColorHex", "Name" },
                values: new object[] { "#595260", "Not Interested" });

            migrationBuilder.UpdateData(
                table: "CandidateStatuses",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ColorHex", "Name" },
                values: new object[] { "#444444", "Decline Offer" });

            migrationBuilder.UpdateData(
                table: "CandidateStatuses",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ColorHex", "Name" },
                values: new object[] { "#6D8299", "Withdrew" });

            migrationBuilder.UpdateData(
                table: "CandidateStatuses",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ColorHex", "Name" },
                values: new object[] { "#DAAB05", "Keep in mind" });

            migrationBuilder.InsertData(
                table: "CandidateStatuses",
                columns: new[] { "Id", "ColorHex", "Name" },
                values: new object[] { 14, "#0B4619", "Former employee" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Select...");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Software Tester Manual");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Software Tester Automation");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Software Tester");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "System Tester");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Software Developer");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Business Analyst");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Requirements Analyst");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Product Owner");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Scrum Master");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "Project Manager");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "Delivery Manager");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13,
                column: "Name",
                value: "Director");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14,
                column: "Name",
                value: "QA Architect");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15,
                column: "Name",
                value: "Development Architect");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16,
                column: "Name",
                value: "DevOps");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17,
                column: "Name",
                value: "Sys Admin");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18,
                column: "Name",
                value: "Recruiter");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19,
                column: "Name",
                value: "HR Specialist");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 20, "Business Development Manager" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Select...");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: ".NET");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Javascript");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Full Stack");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "QA Automation");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "QA");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "DevOps");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Sys Administraton");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Delphi");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Requirements");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "LabVIEW");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "Front end");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 13,
                column: "Name",
                value: "Back end");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 14,
                column: "Name",
                value: "Recruitment");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 15,
                column: "Name",
                value: "Administration");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 16,
                column: "Name",
                value: "Python");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 17,
                column: "Name",
                value: "Product Owner");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 18,
                column: "Name",
                value: "Management");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 19,
                column: "Name",
                value: "Java");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 20,
                column: "Name",
                value: "PHP");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 21,
                column: "Name",
                value: "Embedded C/C++");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 22,
                column: "Name",
                value: "Embedded C");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 23,
                column: "Name",
                value: "C++");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 24,
                column: "Name",
                value: "Angular");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 25,
                column: "Name",
                value: "Angular JS");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 26,
                column: "Name",
                value: "React JS");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 27,
                column: "Name",
                value: "Node JS");

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "Name" },
                values: new object[] { 28, "Cybersecurity" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CandidateStatuses",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.UpdateData(
                table: "CandidateStatuses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ColorHex", "Name" },
                values: new object[] { "#3655B3", "Applied" });

            migrationBuilder.UpdateData(
                table: "CandidateStatuses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ColorHex", "Name" },
                values: new object[] { "#800080", "Contacted" });

            migrationBuilder.UpdateData(
                table: "CandidateStatuses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ColorHex", "Name" },
                values: new object[] { "#5A0049", "Recontacted" });

            migrationBuilder.UpdateData(
                table: "CandidateStatuses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ColorHex", "Name" },
                values: new object[] { "#F07443", "Uncontacted" });

            migrationBuilder.UpdateData(
                table: "CandidateStatuses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ColorHex", "Name" },
                values: new object[] { "#008000", "Hired" });

            migrationBuilder.UpdateData(
                table: "CandidateStatuses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ColorHex", "Name" },
                values: new object[] { "#E04DB0", "In process" });

            migrationBuilder.UpdateData(
                table: "CandidateStatuses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ColorHex", "Name" },
                values: new object[] { "#B30000", "Blacklist" });

            migrationBuilder.UpdateData(
                table: "CandidateStatuses",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ColorHex", "Name" },
                values: new object[] { "#F50A0A", "Rejected" });

            migrationBuilder.UpdateData(
                table: "CandidateStatuses",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ColorHex", "Name" },
                values: new object[] { "#595260", "Not Interested" });

            migrationBuilder.UpdateData(
                table: "CandidateStatuses",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ColorHex", "Name" },
                values: new object[] { "#444444", "Decline Offer" });

            migrationBuilder.UpdateData(
                table: "CandidateStatuses",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ColorHex", "Name" },
                values: new object[] { "#6D8299", "Withdrew" });

            migrationBuilder.UpdateData(
                table: "CandidateStatuses",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ColorHex", "Name" },
                values: new object[] { "#DAAB05", "Keep in mind" });

            migrationBuilder.UpdateData(
                table: "CandidateStatuses",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ColorHex", "Name" },
                values: new object[] { "#0B4619", "Former employee" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Software Tester Manual");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Software Tester Automation");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Software Tester");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "System Tester");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Software Developer");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Business Analyst");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Requirements Analyst");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Product Owner");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Scrum Master");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Project Manager");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "Delivery Manager");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "Director");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13,
                column: "Name",
                value: "QA Architect");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14,
                column: "Name",
                value: "Development Architect");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15,
                column: "Name",
                value: "DevOps");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16,
                column: "Name",
                value: "Sys Admin");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17,
                column: "Name",
                value: "Recruiter");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18,
                column: "Name",
                value: "HR Specialist");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19,
                column: "Name",
                value: "Business Development Manager");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: ".NET");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Javascript");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Full Stack");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "QA Automation");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "QA");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "DevOps");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Sys Administraton");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Delphi");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Requirements");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "LabVIEW");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "Front end");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "Back end");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 13,
                column: "Name",
                value: "Recruitment");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 14,
                column: "Name",
                value: "Administration");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 15,
                column: "Name",
                value: "Python");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 16,
                column: "Name",
                value: "Product Owner");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 17,
                column: "Name",
                value: "Management");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 18,
                column: "Name",
                value: "Java");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 19,
                column: "Name",
                value: "PHP");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 20,
                column: "Name",
                value: "Embedded C/C++");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 21,
                column: "Name",
                value: "Embedded C");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 22,
                column: "Name",
                value: "C++");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 23,
                column: "Name",
                value: "Angular");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 24,
                column: "Name",
                value: "Angular JS");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 25,
                column: "Name",
                value: "React JS");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 26,
                column: "Name",
                value: "Node JS");

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 27,
                column: "Name",
                value: "Cybersecurity");
        }
    }
}
