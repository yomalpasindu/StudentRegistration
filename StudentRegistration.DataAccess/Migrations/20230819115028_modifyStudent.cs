using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentRegistration.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class modifyStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentsTeachers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentsTeachers",
                columns: table => new
                {
                    StudentsId = table.Column<int>(type: "int", nullable: false),
                    TeachersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsTeachers", x => new { x.StudentsId, x.TeachersId });
                    table.ForeignKey(
                        name: "FK_StudentsTeachers_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentsTeachers_Teachers_TeachersId",
                        column: x => x.TeachersId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentsTeachers_TeachersId",
                table: "StudentsTeachers",
                column: "TeachersId");
        }
    }
}
