using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DIPLOMA.Data.Migrations
{
    public partial class AddMsgWidget : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "DonateMsg",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "MsgWidget",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    UserID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Url = table.Column<string>(maxLength: 2000, nullable: true),
                    MinAmt = table.Column<decimal>(type: "decimal(18, 4)", nullable: true, defaultValue: 10m),
                    MaxAmt = table.Column<decimal>(type: "decimal(18, 4)", nullable: true, defaultValue: 1000m),
                    HeaderText = table.Column<string>(nullable: true),
                    MaxSymbols = table.Column<int>(nullable: true, defaultValue: 50),
                    DisplayTimeSec = table.Column<int>(nullable: true, defaultValue: 5),
                    RandomContent = table.Column<bool>(nullable: true),
                    ReadHeader = table.Column<bool>(nullable: true),
                    ReadMessage = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MsgWidget", x => x.ID);
                    table.ForeignKey(
                        name: "FK__MsgWidget_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MsgWidgetContent",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MsgWidgetID = table.Column<Guid>(nullable: true),
                    Picture = table.Column<byte[]>(nullable: true),
                    Sound = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MsgWidgetContent", x => x.ID);
                    table.ForeignKey(
                        name: "FK__MsgWidgetContent_MsgWidgetID",
                        column: x => x.MsgWidgetID,
                        principalTable: "MsgWidget",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MsgWidget_UserID",
                table: "MsgWidget",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_MsgWidgetContent_MsgWidgetID",
                table: "MsgWidgetContent",
                column: "MsgWidgetID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MsgWidgetContent");

            migrationBuilder.DropTable(
                name: "MsgWidget");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "DonateMsg",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
