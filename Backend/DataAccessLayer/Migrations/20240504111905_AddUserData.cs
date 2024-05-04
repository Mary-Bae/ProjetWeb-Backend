using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddUserData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "Roles",
            columns: new[] { "Id", "RoleName" },
            values: new object[,]
            {
                { 1, "admin" },
                { 2, "instructor" },
                { 3, "student" },
                { 4, "guest" }
            }
        );
            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);

            migrationBuilder.InsertData(
               table: "Users",
               columns: new[] { "Username", "Password", "Salt", "RoleId" },
               values: new object[,]
               {
                { "Marylene", "A9A07D9F16BA7728318427022BBE16750AA669DF0A5DD2031E6542AA020732FD18762550274BA661525F6D04EE6AF3F10BC48CE9CCDB91010E6218543CB13F75", "vendredi", 1 },
                { "Sellami", "7AA6F3A0980CED2BD69D0C437A82A1E0E21840CB2BAD40A33C06DABFD4833B0FB60B4928EA1C5A404083206427306B409651DAEF8EA444BDB8FEEEC384591AC7", "vendredi", 1 },
                { "Patrick", "3CF82D32A118E77BAE1B044B1CD47CFBAB426BBF2CB8B96DA37A084C506D9A6BB4068709F0C1024BDD110256CF0970351AFF4EF553DA5C5E5C3A2CE80D83AFD7", "vendredi", 2 },
                { "Fredo", "7C0DB2FF8DBB13E360A8356B436EC59EF0167665F41F491D40788B5CA250A79AE1CD948E9483888B935FFB3D75B8242C059A2D34902197BAB1F351FC92C0F682", "vendredi", 2 },
                { "Laura", "9B91027DDC8C4611C7EBDB926AD11937BAD34A02162663F3BE64D2DD0E9B637225A5C9506DF6373001F68860762300963E18B0B9CAAA983B581C04923204EA2C", "vendredi", 2 },
                { "Laeticia", "098E1C6CF01A9AC0874056B828BBA733784BFFCB5BC4A3EC54FFADB7BEFF9C0FCCEA06234796024E6BD4AFF325116A5522BBF10294E68A6E07C08EF33CD29F98", "vendredi", 2 },
                { "Bertrand", "1A4A107028F4BCA75694AF4E1BBF3ECD9E725948A794304EF3E42714535645EC0F220B09AD547573B05E4A5F6CBC175AEFF3A4ADAAC4B692DF30F72A08D6DDBB", "vendredi", 3 },
                { "Jessica", "C82214ADF14AAEA66F8998614C65B266F05F6D6BEA99DA7590E853C02577AA69241FE25AE2CD39F6D471B07AE96D032FBFA4E2DD60AB1D8DD85A95DF2DEBE81A", "vendredi", 3 },
                { "Jennifer", "A17BE927846E004968806D3E2C03CD933D6D1148E729C8E764E42839EA83093757CD0A90177FE32E1C3F9B62B3D2745717326C511A409C3AC5BE1027C3668230", "vendredi", 3 },
                { "Laurent", "ADB8D88108E495A95CBAF4CC4B2C7AF5554B4BD726E5E7B7550F07B86CD1C231D49D7E401B0D120DFDCF6DF317A9F4C85C8E8880FC2EEA7DDA59CC5686B23690", "vendredi", 3 },
               }
               );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Username",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Username",
                keyValues: new object[] { "Marylene", "Sellami", "Patrick",
                "Fredo", "Laura", "Laeticia", "Bertrand", "Jessica", "Jennifer", "Laurent" }
    );
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4 }
     );
        }
    }
}
