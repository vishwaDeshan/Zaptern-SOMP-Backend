using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Rename_Health_Records_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HealthRecords");

            migrationBuilder.CreateTable(
                name: "ApplicantHealthRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicalConditions = table.Column<bool>(type: "bit", nullable: true),
                    MedicalConditionsDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Medications = table.Column<bool>(type: "bit", nullable: true),
                    MedicationsDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Allergies = table.Column<bool>(type: "bit", nullable: true),
                    AllergiesDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vaccinated = table.Column<bool>(type: "bit", nullable: true),
                    VaccinatedDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surgeries = table.Column<bool>(type: "bit", nullable: true),
                    SurgeriesDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Accommodations = table.Column<bool>(type: "bit", nullable: true),
                    AccommodationsDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantHealthRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicantHealthRecords_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantHealthRecords_ApplicantId",
                table: "ApplicantHealthRecords",
                column: "ApplicantId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicantHealthRecords");

            migrationBuilder.CreateTable(
                name: "HealthRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Accommodations = table.Column<bool>(type: "bit", nullable: true),
                    AccommodationsDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Allergies = table.Column<bool>(type: "bit", nullable: true),
                    AllergiesDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicalConditions = table.Column<bool>(type: "bit", nullable: true),
                    MedicalConditionsDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Medications = table.Column<bool>(type: "bit", nullable: true),
                    MedicationsDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surgeries = table.Column<bool>(type: "bit", nullable: true),
                    SurgeriesDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vaccinated = table.Column<bool>(type: "bit", nullable: true),
                    VaccinatedDetails = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthRecords_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HealthRecords_ApplicantId",
                table: "HealthRecords",
                column: "ApplicantId",
                unique: true);
        }
    }
}
