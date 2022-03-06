using Microsoft.EntityFrameworkCore.Migrations;

namespace DIPLOMA.Data.Migrations
{
    public partial class CascadeDeleateMsgContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MsgWidgetContent_MsgWidget_MsgWidgetID",
                table: "MsgWidgetContent");

            migrationBuilder.AddForeignKey(
                name: "FK_MsgWidgetContent_MsgWidget_MsgWidgetID",
                table: "MsgWidgetContent",
                column: "MsgWidgetID",
                principalTable: "MsgWidget",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MsgWidgetContent_MsgWidget_MsgWidgetID",
                table: "MsgWidgetContent");

            migrationBuilder.AddForeignKey(
                name: "FK_MsgWidgetContent_MsgWidget_MsgWidgetID",
                table: "MsgWidgetContent",
                column: "MsgWidgetID",
                principalTable: "MsgWidget",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
