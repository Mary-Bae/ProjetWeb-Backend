using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddGradesUsersData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
            name: "IX_UserId",
            table: "GradeStudents",
            column: "UserId",
            unique: true);

            migrationBuilder.InsertData(
            table: "GradeStudents",
            columns: new[] { "UserId", "GradeId" },
            values: new object[,]
            {
                { 7, 1 },
                { 8, 1 },
                { 9, 2 },
                { 10, 3 },
            }
        );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserId",
                table: "GradeStudents");

            migrationBuilder.DeleteData(
                table: "GradeStudents",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4 }

            );
        }
    }
}
