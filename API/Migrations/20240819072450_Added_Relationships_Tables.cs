using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Added_Relationships_Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StudentID1",
                table: "Feedbacks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_StudentID1",
                table: "Feedbacks",
                column: "StudentID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Students_StudentID1",
                table: "Feedbacks",
                column: "StudentID1",
                principalTable: "Students",
                principalColumn: "StudentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Students_StudentID1",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_StudentID1",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "StudentID1",
                table: "Feedbacks");
        }
    }
}
