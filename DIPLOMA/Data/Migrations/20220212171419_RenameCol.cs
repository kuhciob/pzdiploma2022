using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DIPLOMA.Data.Migrations
{
    public partial class RenameCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MsgWidgetContent_UploadFile_AminationFileId",
                table: "MsgWidgetContent");

            migrationBuilder.DropIndex(
                name: "IX_MsgWidgetContent_AminationFileId",
                table: "MsgWidgetContent");

            migrationBuilder.DropColumn(
                name: "AminationFileId",
                table: "MsgWidgetContent");

            migrationBuilder.AddColumn<Guid>(
                name: "AnimationFileId",
                table: "MsgWidgetContent",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MsgWidget",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MsgWidgetContent_AnimationFileId",
                table: "MsgWidgetContent",
                column: "AnimationFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_MsgWidgetContent_UploadFile_AnimationFileId",
                table: "MsgWidgetContent",
                column: "AnimationFileId",
                principalTable: "UploadFile",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MsgWidgetContent_UploadFile_AnimationFileId",
                table: "MsgWidgetContent");

            migrationBuilder.DropIndex(
                name: "IX_MsgWidgetContent_AnimationFileId",
                table: "MsgWidgetContent");

            migrationBuilder.DropColumn(
                name: "AnimationFileId",
                table: "MsgWidgetContent");

            migrationBuilder.AddColumn<Guid>(
                name: "AminationFileId",
                table: "MsgWidgetContent",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "MsgWidget",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.CreateIndex(
                name: "IX_MsgWidgetContent_AminationFileId",
                table: "MsgWidgetContent",
                column: "AminationFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_MsgWidgetContent_UploadFile_AminationFileId",
                table: "MsgWidgetContent",
                column: "AminationFileId",
                principalTable: "UploadFile",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
