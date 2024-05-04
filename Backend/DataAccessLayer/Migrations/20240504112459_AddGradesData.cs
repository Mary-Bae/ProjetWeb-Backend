using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddGradesData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
            name: "IX_Grades_Name",
            table: "Grades",
            column:"GradeName",
            unique: true);

            migrationBuilder.InsertData(
            table: "Grades",
            columns: new[] { "Id", "GradeName"},
            values: new object[,]
            {
                { 1, "Beginner" },
                { 2, "Intermediate" },
                { 3, "Confirmed" },
            }
        );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Grades_Name",
                table: "Grades");

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3 }

            );
        }
    }
}
