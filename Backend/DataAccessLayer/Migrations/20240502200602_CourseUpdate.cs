using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class CourseUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
               name: "IX_Courses_UserId",
               table: "Courses");

            migrationBuilder.DropIndex(
               name: "IX_Courses_LevelId",
               table: "Courses");
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Courses_UserId",
                table: "Courses",
                columns: new[] { "Name", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_LevelId",
                table: "Courses",
                columns: new[] { "Name", "Level" },
                unique: true);


        }
    }
}
