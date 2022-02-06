using Microsoft.EntityFrameworkCore.Migrations;

namespace DIPLOMA.Data.Migrations
{
    public partial class AlterBoolMsaWidget : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "ReadMessage",
                table: "MsgWidget",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "ReadHeader",
                table: "MsgWidget",
                nullable: true,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "RandomContent",
                table: "MsgWidget",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaxSymbols",
                table: "MsgWidget",
                nullable: false,
                defaultValue: 50,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValue: 50);

            migrationBuilder.AlterColumn<int>(
                name: "DisplayTimeSec",
                table: "MsgWidget",
                nullable: false,
                defaultValue: 5,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValue: 5);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "ReadMessage",
                table: "MsgWidget",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true,
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "ReadHeader",
                table: "MsgWidget",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true,
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "RandomContent",
                table: "MsgWidget",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "MaxSymbols",
                table: "MsgWidget",
                type: "int",
                nullable: true,
                defaultValue: 50,
                oldClrType: typeof(int),
                oldDefaultValue: 50);

            migrationBuilder.AlterColumn<int>(
                name: "DisplayTimeSec",
                table: "MsgWidget",
                type: "int",
                nullable: true,
                defaultValue: 5,
                oldClrType: typeof(int),
                oldDefaultValue: 5);
        }
    }
}
