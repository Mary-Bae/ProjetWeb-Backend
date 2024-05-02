using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class LevelData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                            table: "Levels",
                            column: "LevelName",
                            values: new object[] { "Rookie", "Debutant", "Confirmé" }
                             );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
            table: "Levels",
            keyColumn: "Id",
            keyValues: new object[] { 1, 2, 3 });
        }

    }
}
