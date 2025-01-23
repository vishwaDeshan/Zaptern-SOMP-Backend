using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_Apllicant_Educational_Details_Relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ApplicantId",
                table: "EducationalDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_EducationalDetails_ApplicantId",
                table: "EducationalDetails",
                column: "ApplicantId");

            migrationBuilder.AddForeignKey(
                name: "FK_EducationalDetails_Applicants_ApplicantId",
                table: "EducationalDetails",
                column: "ApplicantId",
                principalTable: "Applicants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EducationalDetails_Applicants_ApplicantId",
                table: "EducationalDetails");

            migrationBuilder.DropIndex(
                name: "IX_EducationalDetails_ApplicantId",
                table: "EducationalDetails");

            migrationBuilder.DropColumn(
                name: "ApplicantId",
                table: "EducationalDetails");
        }
    }
}
