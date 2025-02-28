using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update_Keys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantHealthRecords_Applicants_ApplicantId",
                table: "ApplicantHealthRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_EducationalDetails_Applicants_ApplicantId",
                table: "EducationalDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Applicants",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "InstituteName",
                table: "EducationalDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Applicants",
                table: "Applicants",
                column: "ApplicantId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantHealthRecords_Applicants_ApplicantId",
                table: "ApplicantHealthRecords",
                column: "ApplicantId",
                principalTable: "Applicants",
                principalColumn: "ApplicantId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EducationalDetails_Applicants_ApplicantId",
                table: "EducationalDetails",
                column: "ApplicantId",
                principalTable: "Applicants",
                principalColumn: "ApplicantId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantHealthRecords_Applicants_ApplicantId",
                table: "ApplicantHealthRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_EducationalDetails_Applicants_ApplicantId",
                table: "EducationalDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Applicants",
                table: "Applicants");

            migrationBuilder.AddColumn<string>(
                name: "InstituteName",
                table: "EducationalDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Applicants",
                table: "Applicants",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantHealthRecords_Applicants_ApplicantId",
                table: "ApplicantHealthRecords",
                column: "ApplicantId",
                principalTable: "Applicants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EducationalDetails_Applicants_ApplicantId",
                table: "EducationalDetails",
                column: "ApplicantId",
                principalTable: "Applicants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
