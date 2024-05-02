using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class UserData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                            table: "Users",
                            columns: new[] { "Username", "Password", "Salt", "RoleId" },
                            values: new object[,]
                             {
                                 { "user1", "829792F8543443A91F7E", "Sunday", "3" }, //test
                                 { "user2", "EE1D043DE283E12CD10A", "Sunday", "1" }, //password
                                 { "user3", "A06EE0913A1EBFCE55EF", "Sunday", "2" } //secret
                             });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3 });
        }
    }
}
