using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class CourseData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                            table: "Courses",
                            columns: new[] { "Name", "Schedule", "UserId", "Description", "LevelId" },
                            values: new object[,]
                             {
                                 { "Web", "Day", "2","Cours de web pour les Rookies", "1" },
                                 { "Reseau", "Day", "2", "Cours de reseau pour les débutants","2" },
                                 { "SQL", "Evening","2", "Cours de SQL pour les débutants","2"},
                                 { "Devops", "Evening","2", "Cours de devops pour les confirmés","3" },
                                 { "Web2", "Evening","2", "Cours de web pour les confirmés","3" },
                             });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
           table: "Courses",
           keyColumn: "Id",
           keyValues: new object[] { 1, 2, 3, 4, 5 });
        }
    }
}
