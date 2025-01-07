using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update_Applicant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.RenameColumn(
                name: "HomeCity",
                table: "Applicants",
                newName: "ZipCode");

            migrationBuilder.RenameColumn(
                name: "HomeAddress",
                table: "Applicants",
                newName: "Street");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Applicants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Applicants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Applicants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Applicants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Applicants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Hobbies",
                table: "Applicants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Applicants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "Applicants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Applicants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OtherHobbies",
                table: "Applicants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pronouns",
                table: "Applicants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "Hobbies",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "OtherHobbies",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "Pronouns",
                table: "Applicants");

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "Applicants",
                newName: "HomeCity");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Applicants",
                newName: "HomeAddress");

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });
        }
    }
}
