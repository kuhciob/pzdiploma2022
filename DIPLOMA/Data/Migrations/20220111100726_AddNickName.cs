using Microsoft.EntityFrameworkCore.Migrations;

namespace DIPLOMA.Data.Migrations
{
    public partial class AddNickName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NickName",
                table: "AspNetUsers",
                maxLength: 20,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_NickName",
                table: "AspNetUsers",
                column: "NickName",
                unique: true,
                filter: "[NickName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_NickName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NickName",
                table: "AspNetUsers");
        }
    }
}
