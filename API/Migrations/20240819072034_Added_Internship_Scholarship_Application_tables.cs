using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Added_Internship_Scholarship_Application_tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Internships",
                columns: table => new
                {
                    InternshipID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EligibilityCriteria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostedByAdminID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Internships", x => x.InternshipID);
                    table.ForeignKey(
                        name: "FK_Internships_Administrators_PostedByAdminID",
                        column: x => x.PostedByAdminID,
                        principalTable: "Administrators",
                        principalColumn: "AdminID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Scholarships",
                columns: table => new
                {
                    ScholarshipID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EligibilityCriteria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationDeadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostedByAdminID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scholarships", x => x.ScholarshipID);
                    table.ForeignKey(
                        name: "FK_Scholarships_Administrators_PostedByAdminID",
                        column: x => x.PostedByAdminID,
                        principalTable: "Administrators",
                        principalColumn: "AdminID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationForms",
                columns: table => new
                {
                    ApplicationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    SubmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReviewedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StudentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InternshipID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ScholarshipID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReviewedByAdminID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationForms", x => x.ApplicationID);
                    table.ForeignKey(
                        name: "FK_ApplicationForms_Administrators_ReviewedByAdminID",
                        column: x => x.ReviewedByAdminID,
                        principalTable: "Administrators",
                        principalColumn: "AdminID");
                    table.ForeignKey(
                        name: "FK_ApplicationForms_Internships_InternshipID",
                        column: x => x.InternshipID,
                        principalTable: "Internships",
                        principalColumn: "InternshipID");
                    table.ForeignKey(
                        name: "FK_ApplicationForms_Scholarships_ScholarshipID",
                        column: x => x.ScholarshipID,
                        principalTable: "Scholarships",
                        principalColumn: "ScholarshipID");
                    table.ForeignKey(
                        name: "FK_ApplicationForms_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationForms_InternshipID",
                table: "ApplicationForms",
                column: "InternshipID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationForms_ReviewedByAdminID",
                table: "ApplicationForms",
                column: "ReviewedByAdminID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationForms_ScholarshipID",
                table: "ApplicationForms",
                column: "ScholarshipID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationForms_StudentID",
                table: "ApplicationForms",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Internships_PostedByAdminID",
                table: "Internships",
                column: "PostedByAdminID");

            migrationBuilder.CreateIndex(
                name: "IX_Scholarships_PostedByAdminID",
                table: "Scholarships",
                column: "PostedByAdminID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationForms");

            migrationBuilder.DropTable(
                name: "Internships");

            migrationBuilder.DropTable(
                name: "Scholarships");
        }
    }
}
