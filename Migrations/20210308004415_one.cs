using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Advertisement_LTd.Migrations
{
    public partial class one : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_of_candidate = table.Column<string>(nullable: false),
                    DOB_of_candidate = table.Column<DateTime>(nullable: false),
                    Mobile_no_of_candidate = table.Column<string>(nullable: false),
                    Email_address_of_candidate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Employer_name = table.Column<string>(nullable: true),
                    Date_of_establishment = table.Column<DateTime>(nullable: false),
                    Address_of_employer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Job_Detail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Job_role = table.Column<string>(nullable: true),
                    Job_type = table.Column<string>(nullable: true),
                    Job_salary = table.Column<decimal>(nullable: false),
                    Job_description = table.Column<string>(nullable: true),
                    EmployerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job_Detail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Job_Detail_Employer_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "Employer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Apply_Job_Detail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateId = table.Column<int>(nullable: false),
                    Job_DetailId = table.Column<int>(nullable: false),
                    Candidate_availabilities = table.Column<string>(nullable: false),
                    Candidate_notice_period = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apply_Job_Detail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apply_Job_Detail_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Apply_Job_Detail_Job_Detail_Job_DetailId",
                        column: x => x.Job_DetailId,
                        principalTable: "Job_Detail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apply_Job_Detail_CandidateId",
                table: "Apply_Job_Detail",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_Apply_Job_Detail_Job_DetailId",
                table: "Apply_Job_Detail",
                column: "Job_DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Job_Detail_EmployerId",
                table: "Job_Detail",
                column: "EmployerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apply_Job_Detail");

            migrationBuilder.DropTable(
                name: "Candidate");

            migrationBuilder.DropTable(
                name: "Job_Detail");

            migrationBuilder.DropTable(
                name: "Employer");
        }
    }
}
