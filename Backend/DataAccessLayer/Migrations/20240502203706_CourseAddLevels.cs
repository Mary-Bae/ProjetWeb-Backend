using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class CourseAddLevels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
            table: "Courses",
            keyColumn: "Name",
            keyValue: "Web",
            column: "LevelName",
            value: "Rookie");

            migrationBuilder.UpdateData(
            table: "Courses",
            keyColumn: "Name",
            keyValue: "Reseau",
            column: "LevelName",
            value: "Débutant");

            migrationBuilder.UpdateData(
            table: "Courses",
            keyColumn: "Name",
            keyValue: "SQL",
            column: "LevelName",
            value: "Débutant");

            migrationBuilder.UpdateData(
            table: "Courses",
            keyColumn: "Name",
            keyValue: "Devops",
            column: "LevelName",
            value: "Confirmé");

            migrationBuilder.UpdateData(
            table: "Courses",
            keyColumn: "Name",
            keyValue: "Web2",
            column: "LevelName",
            value: "Confirmé");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
