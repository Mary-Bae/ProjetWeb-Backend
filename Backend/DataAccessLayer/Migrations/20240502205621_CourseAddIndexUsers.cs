using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class CourseAddIndexUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Courses_UserId",
                table: "Courses",
                column: "UserId");

            migrationBuilder.CreateIndex(
            name: "IX_Courses_Name_LevelName",
            table: "Courses",
            columns: new[] { "Name", "LevelName" },
            unique: true);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
            name: "IX_Courses_UserId",
            table: "Courses");

            migrationBuilder.DropIndex(
            name: "IX_Courses_Name_LevelName",
            table: "Courses");
        }
    }
}
