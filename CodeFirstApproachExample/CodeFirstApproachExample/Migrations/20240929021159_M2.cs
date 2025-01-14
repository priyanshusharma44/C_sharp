using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirstApproachExample.Migrations
{
    /// <inheritdoc />
    public partial class M2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Faculties_StudentFacultyFacultyId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "StudentFacultyFacultyId",
                table: "Students",
                newName: "FacultyId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_StudentFacultyFacultyId",
                table: "Students",
                newName: "IX_Students_FacultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Faculties_FacultyId",
                table: "Students",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "FacultyId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Faculties_FacultyId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "FacultyId",
                table: "Students",
                newName: "StudentFacultyFacultyId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_FacultyId",
                table: "Students",
                newName: "IX_Students_StudentFacultyFacultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Faculties_StudentFacultyFacultyId",
                table: "Students",
                column: "StudentFacultyFacultyId",
                principalTable: "Faculties",
                principalColumn: "FacultyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
