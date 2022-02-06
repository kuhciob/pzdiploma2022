using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DIPLOMA.Data.Migrations
{
    public partial class MetaDateAndUploadedFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__MsgWidgetContent_MsgWidgetID",
                table: "MsgWidgetContent");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "MsgWidgetContent");

            migrationBuilder.DropColumn(
                name: "Sound",
                table: "MsgWidgetContent");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "DonateMsg");

            migrationBuilder.AddColumn<Guid>(
                name: "AminationFileId",
                table: "MsgWidgetContent",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SoundFileId",
                table: "MsgWidgetContent",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "MsgWidget",
                nullable: false,
                defaultValue: DateTime.Now);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "MsgWidget",
                nullable: false,
                defaultValue: DateTime.Now);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "DonateMsg",
                nullable: false,
                defaultValue: DateTime.Now);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "DonateMsg",
                nullable: false,
                defaultValue: DateTime.Now);

            migrationBuilder.CreateTable(
                name: "UploadFile",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    Extension = table.Column<string>(maxLength: 20, nullable: true),
                    Data = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadFile", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MsgWidgetContent_AminationFileId",
                table: "MsgWidgetContent",
                column: "AminationFileId");

            migrationBuilder.CreateIndex(
                name: "IX_MsgWidgetContent_SoundFileId",
                table: "MsgWidgetContent",
                column: "SoundFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_MsgWidgetContent_UploadFile_AminationFileId",
                table: "MsgWidgetContent",
                column: "AminationFileId",
                principalTable: "UploadFile",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MsgWidgetContent_MsgWidget_MsgWidgetID",
                table: "MsgWidgetContent",
                column: "MsgWidgetID",
                principalTable: "MsgWidget",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MsgWidgetContent_UploadFile_SoundFileId",
                table: "MsgWidgetContent",
                column: "SoundFileId",
                principalTable: "UploadFile",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MsgWidgetContent_UploadFile_AminationFileId",
                table: "MsgWidgetContent");

            migrationBuilder.DropForeignKey(
                name: "FK_MsgWidgetContent_MsgWidget_MsgWidgetID",
                table: "MsgWidgetContent");

            migrationBuilder.DropForeignKey(
                name: "FK_MsgWidgetContent_UploadFile_SoundFileId",
                table: "MsgWidgetContent");

            migrationBuilder.DropTable(
                name: "UploadFile");

            migrationBuilder.DropIndex(
                name: "IX_MsgWidgetContent_AminationFileId",
                table: "MsgWidgetContent");

            migrationBuilder.DropIndex(
                name: "IX_MsgWidgetContent_SoundFileId",
                table: "MsgWidgetContent");

            migrationBuilder.DropColumn(
                name: "AminationFileId",
                table: "MsgWidgetContent");

            migrationBuilder.DropColumn(
                name: "SoundFileId",
                table: "MsgWidgetContent");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "MsgWidget");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "MsgWidget");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "DonateMsg");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "DonateMsg");

            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "MsgWidgetContent",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Sound",
                table: "MsgWidgetContent",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "DonateMsg",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK__MsgWidgetContent_MsgWidgetID",
                table: "MsgWidgetContent",
                column: "MsgWidgetID",
                principalTable: "MsgWidget",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
