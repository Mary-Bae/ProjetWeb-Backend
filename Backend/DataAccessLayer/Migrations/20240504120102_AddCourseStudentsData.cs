using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddCourseStudentsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
            name: "IX_CourseStudents_UserId_CourseId",
            table: "CourseStudents",
            columns: new[] { "UserId", "CourseId" },
            unique: true);

            migrationBuilder.InsertData(
            table: "CourseStudents",
            columns: new[] { "UserId", "CourseId" },
            values: new object[,]
            {
                { 7, 1 },
                { 7, 5 },
                { 8, 1 },
                { 8, 5 },
                { 9, 2 },
                { 9, 3 },
                { 10, 4 },
            }
        );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CourseStudents_UserId_CourseId",
                table: "CourseStudents");

            migrationBuilder.DeleteData(
                table: "CourseStudents",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4, 5, 6, 7 }

            );
        }
    }
}
