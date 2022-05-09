using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DIPLOMA.Data.Migrations
{
    public partial class AddUserProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Underline",
                table: "TextStyle",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "TextColorHex",
                table: "TextStyle",
                type: "nvarchar(7)",
                nullable: true,
                defaultValue: "#000000",
                oldClrType: typeof(string),
                oldType: "nvarchar(7)",
                oldNullable: true,
                oldDefaultValue: "#ffffff");

            migrationBuilder.AlterColumn<bool>(
                name: "Italic",
                table: "TextStyle",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "Bold",
                table: "TextStyle",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: false);

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

            migrationBuilder.AlterColumn<bool>(
                name: "RandomContent",
                table: "MsgWidget",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: false);

            migrationBuilder.CreateTable(
                name: "UserProfile",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Instagram = table.Column<string>(nullable: true),
                    Discord = table.Column<string>(nullable: true),
                    Twitter = table.Column<string>(nullable: true),
                    Facebook = table.Column<string>(nullable: true),
                    Youtube = table.Column<string>(nullable: true),
                    Twitch = table.Column<string>(nullable: true),
                    Telegram = table.Column<string>(nullable: true),
                    Bio = table.Column<string>(nullable: true),
                    BackgroundImgId = table.Column<Guid>(nullable: true),
                    ProfilePicId = table.Column<Guid>(nullable: true),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfile", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserProfile_UploadFile_BackgroundImgId",
                        column: x => x.BackgroundImgId,
                        principalTable: "UploadFile",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProfile_UploadFile_ProfilePicId",
                        column: x => x.ProfilePicId,
                        principalTable: "UploadFile",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProfile_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "StatWidgetDirectionType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 6, 21, 57, 7, 957, DateTimeKind.Local).AddTicks(3855), new DateTime(2022, 5, 6, 21, 57, 7, 957, DateTimeKind.Local).AddTicks(4016) });

            migrationBuilder.UpdateData(
                table: "StatWidgetDirectionType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 6, 21, 57, 7, 957, DateTimeKind.Local).AddTicks(4744), new DateTime(2022, 5, 6, 21, 57, 7, 957, DateTimeKind.Local).AddTicks(4767) });

            migrationBuilder.UpdateData(
                table: "StatWidgetDirectionType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 6, 21, 57, 7, 957, DateTimeKind.Local).AddTicks(4790), new DateTime(2022, 5, 6, 21, 57, 7, 957, DateTimeKind.Local).AddTicks(4795) });

            migrationBuilder.UpdateData(
                table: "StatWidgetDirectionType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 6, 21, 57, 7, 957, DateTimeKind.Local).AddTicks(4802), new DateTime(2022, 5, 6, 21, 57, 7, 957, DateTimeKind.Local).AddTicks(4807) });

            migrationBuilder.UpdateData(
                table: "StatWidgetDisplayModeType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 6, 21, 57, 7, 938, DateTimeKind.Local).AddTicks(6674), new DateTime(2022, 5, 6, 21, 57, 7, 944, DateTimeKind.Local).AddTicks(3668) });

            migrationBuilder.UpdateData(
                table: "StatWidgetDisplayModeType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 6, 21, 57, 7, 944, DateTimeKind.Local).AddTicks(5835), new DateTime(2022, 5, 6, 21, 57, 7, 944, DateTimeKind.Local).AddTicks(5875) });

            migrationBuilder.UpdateData(
                table: "StatWidgetDisplayModeType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 6, 21, 57, 7, 944, DateTimeKind.Local).AddTicks(6009), new DateTime(2022, 5, 6, 21, 57, 7, 944, DateTimeKind.Local).AddTicks(6025) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 6, 21, 57, 7, 955, DateTimeKind.Local).AddTicks(4250), new DateTime(2022, 5, 6, 21, 57, 7, 955, DateTimeKind.Local).AddTicks(4323) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 6, 21, 57, 7, 955, DateTimeKind.Local).AddTicks(4369), new DateTime(2022, 5, 6, 21, 57, 7, 955, DateTimeKind.Local).AddTicks(4374) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 6, 21, 57, 7, 955, DateTimeKind.Local).AddTicks(4381), new DateTime(2022, 5, 6, 21, 57, 7, 955, DateTimeKind.Local).AddTicks(4387) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 6, 21, 57, 7, 955, DateTimeKind.Local).AddTicks(4407), new DateTime(2022, 5, 6, 21, 57, 7, 955, DateTimeKind.Local).AddTicks(4411) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 6, 21, 57, 7, 955, DateTimeKind.Local).AddTicks(4415), new DateTime(2022, 5, 6, 21, 57, 7, 955, DateTimeKind.Local).AddTicks(4419) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 6, 21, 57, 7, 955, DateTimeKind.Local).AddTicks(4424), new DateTime(2022, 5, 6, 21, 57, 7, 955, DateTimeKind.Local).AddTicks(4428) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 6, 21, 57, 7, 955, DateTimeKind.Local).AddTicks(4433), new DateTime(2022, 5, 6, 21, 57, 7, 955, DateTimeKind.Local).AddTicks(4438) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 6, 21, 57, 7, 955, DateTimeKind.Local).AddTicks(4444), new DateTime(2022, 5, 6, 21, 57, 7, 955, DateTimeKind.Local).AddTicks(4450) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 6, 21, 57, 7, 955, DateTimeKind.Local).AddTicks(4456), new DateTime(2022, 5, 6, 21, 57, 7, 955, DateTimeKind.Local).AddTicks(4461) });

            migrationBuilder.UpdateData(
                table: "StatWidgetType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 6, 21, 57, 7, 951, DateTimeKind.Local).AddTicks(2055), new DateTime(2022, 5, 6, 21, 57, 7, 951, DateTimeKind.Local).AddTicks(2134) });

            migrationBuilder.UpdateData(
                table: "StatWidgetType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 6, 21, 57, 7, 951, DateTimeKind.Local).AddTicks(2191), new DateTime(2022, 5, 6, 21, 57, 7, 951, DateTimeKind.Local).AddTicks(2197) });

            migrationBuilder.UpdateData(
                table: "StatWidgetType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 6, 21, 57, 7, 951, DateTimeKind.Local).AddTicks(2203), new DateTime(2022, 5, 6, 21, 57, 7, 951, DateTimeKind.Local).AddTicks(2206) });

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_BackgroundImgId",
                table: "UserProfile",
                column: "BackgroundImgId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_ProfilePicId",
                table: "UserProfile",
                column: "ProfilePicId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_UserID",
                table: "UserProfile",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProfile");

            migrationBuilder.AlterColumn<bool>(
                name: "Underline",
                table: "TextStyle",
                type: "bit",
                nullable: true,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "TextColorHex",
                table: "TextStyle",
                type: "nvarchar(7)",
                nullable: true,
                defaultValue: "#ffffff",
                oldClrType: typeof(string),
                oldType: "nvarchar(7)",
                oldNullable: true,
                oldDefaultValue: "#000000");

            migrationBuilder.AlterColumn<bool>(
                name: "Italic",
                table: "TextStyle",
                type: "bit",
                nullable: true,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "Bold",
                table: "TextStyle",
                type: "bit",
                nullable: true,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

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

            migrationBuilder.AlterColumn<bool>(
                name: "RandomContent",
                table: "MsgWidget",
                type: "bit",
                nullable: true,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.UpdateData(
                table: "StatWidgetDirectionType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 2, 10, 58, 42, 577, DateTimeKind.Local).AddTicks(5356), new DateTime(2022, 5, 2, 10, 58, 42, 577, DateTimeKind.Local).AddTicks(5433) });

            migrationBuilder.UpdateData(
                table: "StatWidgetDirectionType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 2, 10, 58, 42, 577, DateTimeKind.Local).AddTicks(6103), new DateTime(2022, 5, 2, 10, 58, 42, 577, DateTimeKind.Local).AddTicks(6120) });

            migrationBuilder.UpdateData(
                table: "StatWidgetDirectionType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 2, 10, 58, 42, 577, DateTimeKind.Local).AddTicks(6143), new DateTime(2022, 5, 2, 10, 58, 42, 577, DateTimeKind.Local).AddTicks(6151) });

            migrationBuilder.UpdateData(
                table: "StatWidgetDirectionType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 2, 10, 58, 42, 577, DateTimeKind.Local).AddTicks(6157), new DateTime(2022, 5, 2, 10, 58, 42, 577, DateTimeKind.Local).AddTicks(6163) });

            migrationBuilder.UpdateData(
                table: "StatWidgetDisplayModeType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 2, 10, 58, 42, 562, DateTimeKind.Local).AddTicks(1218), new DateTime(2022, 5, 2, 10, 58, 42, 570, DateTimeKind.Local).AddTicks(3766) });

            migrationBuilder.UpdateData(
                table: "StatWidgetDisplayModeType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 2, 10, 58, 42, 570, DateTimeKind.Local).AddTicks(5278), new DateTime(2022, 5, 2, 10, 58, 42, 570, DateTimeKind.Local).AddTicks(5310) });

            migrationBuilder.UpdateData(
                table: "StatWidgetDisplayModeType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 2, 10, 58, 42, 570, DateTimeKind.Local).AddTicks(5352), new DateTime(2022, 5, 2, 10, 58, 42, 570, DateTimeKind.Local).AddTicks(5359) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 2, 10, 58, 42, 575, DateTimeKind.Local).AddTicks(8643), new DateTime(2022, 5, 2, 10, 58, 42, 575, DateTimeKind.Local).AddTicks(8711) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 2, 10, 58, 42, 575, DateTimeKind.Local).AddTicks(8755), new DateTime(2022, 5, 2, 10, 58, 42, 575, DateTimeKind.Local).AddTicks(8762) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 2, 10, 58, 42, 575, DateTimeKind.Local).AddTicks(8769), new DateTime(2022, 5, 2, 10, 58, 42, 575, DateTimeKind.Local).AddTicks(8775) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 2, 10, 58, 42, 575, DateTimeKind.Local).AddTicks(8782), new DateTime(2022, 5, 2, 10, 58, 42, 575, DateTimeKind.Local).AddTicks(8788) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 2, 10, 58, 42, 575, DateTimeKind.Local).AddTicks(8795), new DateTime(2022, 5, 2, 10, 58, 42, 575, DateTimeKind.Local).AddTicks(8801) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 2, 10, 58, 42, 575, DateTimeKind.Local).AddTicks(8808), new DateTime(2022, 5, 2, 10, 58, 42, 575, DateTimeKind.Local).AddTicks(8813) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 2, 10, 58, 42, 575, DateTimeKind.Local).AddTicks(8820), new DateTime(2022, 5, 2, 10, 58, 42, 575, DateTimeKind.Local).AddTicks(8826) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 2, 10, 58, 42, 575, DateTimeKind.Local).AddTicks(8833), new DateTime(2022, 5, 2, 10, 58, 42, 575, DateTimeKind.Local).AddTicks(8838) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 2, 10, 58, 42, 575, DateTimeKind.Local).AddTicks(8845), new DateTime(2022, 5, 2, 10, 58, 42, 575, DateTimeKind.Local).AddTicks(8851) });

            migrationBuilder.UpdateData(
                table: "StatWidgetType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 2, 10, 58, 42, 573, DateTimeKind.Local).AddTicks(9533), new DateTime(2022, 5, 2, 10, 58, 42, 573, DateTimeKind.Local).AddTicks(9604) });

            migrationBuilder.UpdateData(
                table: "StatWidgetType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 2, 10, 58, 42, 573, DateTimeKind.Local).AddTicks(9658), new DateTime(2022, 5, 2, 10, 58, 42, 573, DateTimeKind.Local).AddTicks(9665) });

            migrationBuilder.UpdateData(
                table: "StatWidgetType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 2, 10, 58, 42, 573, DateTimeKind.Local).AddTicks(9673), new DateTime(2022, 5, 2, 10, 58, 42, 573, DateTimeKind.Local).AddTicks(9678) });
        }
    }
}
