using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class CourseStudentsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                            table: "CourseStudents",
                            columns: new[] { "UserId", "CourseId" },
                            values: new object[,]
                             {
                                 { "1", "1" },
                                 { "1", "2" },
                                 { "1", "3" },
                                 { "1", "4" },
                                 { "1", "5" },
                             });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
            table: "CourseStudents",
            keyColumn: "Id",
            keyValues: new object[] { 1, 2, 3, 4, 5 });
        }
    }
}
