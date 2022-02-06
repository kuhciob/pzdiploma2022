using Microsoft.EntityFrameworkCore.Migrations;

namespace DIPLOMA.Data.Migrations
{
    public partial class AlterBoolMsaWidget2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "ReadMessage",
                table: "MsgWidget",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "ReadHeader",
                table: "MsgWidget",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "ReadMessage",
                table: "MsgWidget",
                type: "bit",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "ReadHeader",
                table: "MsgWidget",
                type: "bit",
                nullable: true,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);
        }
    }
}
