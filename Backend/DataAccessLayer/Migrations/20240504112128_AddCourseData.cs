using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddCourseData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
            name: "IX_Courses_Name_LevelName",
            table: "Courses",
            columns: new[] { "Name", "LevelName" },
            unique: true);

            migrationBuilder.CreateIndex(
            name: "IX_Courses_Name_LevelName_UserId",
            table: "Courses",
            columns: new[] { "Name", "LevelName", "UserId" },
            unique: true);

            migrationBuilder.InsertData(
            table: "Courses",
            columns: new[] { "Name", "Schedule", "UserId", "Description", "LevelName" },
            values: new object[,]
            {
                { "Web", "Day", 3, "Cours de web pour les débutants", "Beginner" },
                { "Reseau", "Day", 4, "Cours de reseau pour les intermédiaires", "Intermediate" },
                { "SQL", "Evening", 4, "Cours de SQL pour les intermédiaires", "Intermediate" },
                { "Devops", "Day", 5, "Cours de devops pour les confirmés", "Confirmed" },
                { "Analyse", "Evening", 6, "Cours d'analyse pour les débutants", "Beginner" },
            }
        );

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
            name: "IX_Courses_Name_LevelName_UserId",
            table: "Courses");

            migrationBuilder.DropIndex(
            name: "IX_Courses_Name_LevelName",
            table: "Courses");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4, 5 }
        );

        }

    }
}
