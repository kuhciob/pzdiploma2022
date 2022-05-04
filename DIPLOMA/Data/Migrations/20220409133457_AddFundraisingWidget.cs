using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DIPLOMA.Data.Migrations
{
    public partial class AddFundraisingWidget : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FundraisingWidget",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Url = table.Column<string>(maxLength: 2000, nullable: true),
                    HeaderText = table.Column<string>(nullable: true),
                    InitialAmt = table.Column<decimal>(type: "decimal(18, 4)", nullable: true, defaultValue: 0m),
                    TargetAmt = table.Column<decimal>(nullable: true, defaultValue: 0m),
                    CollectedAmt = table.Column<decimal>(type: "decimal(18, 4)", nullable: true, defaultValue: 0m),
                    HideInitAndTargetAmounts = table.Column<bool>(nullable: false, defaultValue: false),
                    Active = table.Column<bool>(nullable: false),
                    IndicatorColorHex = table.Column<string>(type: "nvarchar(7)", nullable: true, defaultValue: "#000000"),
                    IndicatorBackgroundColorHex = table.Column<string>(type: "nvarchar(7)", nullable: true, defaultValue: "#ffffff"),
                    BorderColorHex = table.Column<string>(type: "nvarchar(7)", nullable: true, defaultValue: "#000000"),
                    DigitsColorHex = table.Column<string>(type: "nvarchar(7)", nullable: true, defaultValue: "#000000"),
                    BorderSize = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    Radius = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundraisingWidget", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FundraisingWidget_AspNetUsers_UserID",
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
                values: new object[] { new DateTime(2022, 4, 9, 16, 34, 56, 421, DateTimeKind.Local).AddTicks(3358), new DateTime(2022, 4, 9, 16, 34, 56, 421, DateTimeKind.Local).AddTicks(3422) });

            migrationBuilder.UpdateData(
                table: "StatWidgetDirectionType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 4, 9, 16, 34, 56, 421, DateTimeKind.Local).AddTicks(3878), new DateTime(2022, 4, 9, 16, 34, 56, 421, DateTimeKind.Local).AddTicks(3892) });

            migrationBuilder.UpdateData(
                table: "StatWidgetDirectionType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 4, 9, 16, 34, 56, 421, DateTimeKind.Local).AddTicks(3907), new DateTime(2022, 4, 9, 16, 34, 56, 421, DateTimeKind.Local).AddTicks(3911) });

            migrationBuilder.UpdateData(
                table: "StatWidgetDirectionType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 4, 9, 16, 34, 56, 421, DateTimeKind.Local).AddTicks(3914), new DateTime(2022, 4, 9, 16, 34, 56, 421, DateTimeKind.Local).AddTicks(3917) });

            migrationBuilder.UpdateData(
                table: "StatWidgetDisplayModeType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 4, 9, 16, 34, 56, 410, DateTimeKind.Local).AddTicks(6806), new DateTime(2022, 4, 9, 16, 34, 56, 415, DateTimeKind.Local).AddTicks(9467) });

            migrationBuilder.UpdateData(
                table: "StatWidgetDisplayModeType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 4, 9, 16, 34, 56, 416, DateTimeKind.Local).AddTicks(512), new DateTime(2022, 4, 9, 16, 34, 56, 416, DateTimeKind.Local).AddTicks(535) });

            migrationBuilder.UpdateData(
                table: "StatWidgetDisplayModeType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 4, 9, 16, 34, 56, 416, DateTimeKind.Local).AddTicks(558), new DateTime(2022, 4, 9, 16, 34, 56, 416, DateTimeKind.Local).AddTicks(561) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 4, 9, 16, 34, 56, 420, DateTimeKind.Local).AddTicks(2059), new DateTime(2022, 4, 9, 16, 34, 56, 420, DateTimeKind.Local).AddTicks(2123) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 4, 9, 16, 34, 56, 420, DateTimeKind.Local).AddTicks(2151), new DateTime(2022, 4, 9, 16, 34, 56, 420, DateTimeKind.Local).AddTicks(2155) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 4, 9, 16, 34, 56, 420, DateTimeKind.Local).AddTicks(2158), new DateTime(2022, 4, 9, 16, 34, 56, 420, DateTimeKind.Local).AddTicks(2161) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 4, 9, 16, 34, 56, 420, DateTimeKind.Local).AddTicks(2165), new DateTime(2022, 4, 9, 16, 34, 56, 420, DateTimeKind.Local).AddTicks(2168) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 4, 9, 16, 34, 56, 420, DateTimeKind.Local).AddTicks(2171), new DateTime(2022, 4, 9, 16, 34, 56, 420, DateTimeKind.Local).AddTicks(2174) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 4, 9, 16, 34, 56, 420, DateTimeKind.Local).AddTicks(2177), new DateTime(2022, 4, 9, 16, 34, 56, 420, DateTimeKind.Local).AddTicks(2180) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 4, 9, 16, 34, 56, 420, DateTimeKind.Local).AddTicks(2183), new DateTime(2022, 4, 9, 16, 34, 56, 420, DateTimeKind.Local).AddTicks(2186) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 4, 9, 16, 34, 56, 420, DateTimeKind.Local).AddTicks(2190), new DateTime(2022, 4, 9, 16, 34, 56, 420, DateTimeKind.Local).AddTicks(2193) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 4, 9, 16, 34, 56, 420, DateTimeKind.Local).AddTicks(2196), new DateTime(2022, 4, 9, 16, 34, 56, 420, DateTimeKind.Local).AddTicks(2199) });

            migrationBuilder.UpdateData(
                table: "StatWidgetType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 4, 9, 16, 34, 56, 418, DateTimeKind.Local).AddTicks(5010), new DateTime(2022, 4, 9, 16, 34, 56, 418, DateTimeKind.Local).AddTicks(5073) });

            migrationBuilder.UpdateData(
                table: "StatWidgetType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 4, 9, 16, 34, 56, 418, DateTimeKind.Local).AddTicks(5114), new DateTime(2022, 4, 9, 16, 34, 56, 418, DateTimeKind.Local).AddTicks(5127) });

            migrationBuilder.UpdateData(
                table: "StatWidgetType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 4, 9, 16, 34, 56, 418, DateTimeKind.Local).AddTicks(5141), new DateTime(2022, 4, 9, 16, 34, 56, 418, DateTimeKind.Local).AddTicks(5153) });

            migrationBuilder.CreateIndex(
                name: "IX_FundraisingWidget_UserID",
                table: "FundraisingWidget",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FundraisingWidget");

            migrationBuilder.UpdateData(
                table: "StatWidgetDirectionType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 3, 31, 15, 56, 30, 842, DateTimeKind.Local).AddTicks(1065), new DateTime(2022, 3, 31, 15, 56, 30, 842, DateTimeKind.Local).AddTicks(1132) });

            migrationBuilder.UpdateData(
                table: "StatWidgetDirectionType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 3, 31, 15, 56, 30, 842, DateTimeKind.Local).AddTicks(1762), new DateTime(2022, 3, 31, 15, 56, 30, 842, DateTimeKind.Local).AddTicks(1781) });

            migrationBuilder.UpdateData(
                table: "StatWidgetDirectionType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 3, 31, 15, 56, 30, 842, DateTimeKind.Local).AddTicks(1802), new DateTime(2022, 3, 31, 15, 56, 30, 842, DateTimeKind.Local).AddTicks(1808) });

            migrationBuilder.UpdateData(
                table: "StatWidgetDirectionType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 3, 31, 15, 56, 30, 842, DateTimeKind.Local).AddTicks(1815), new DateTime(2022, 3, 31, 15, 56, 30, 842, DateTimeKind.Local).AddTicks(1820) });

            migrationBuilder.UpdateData(
                table: "StatWidgetDisplayModeType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 3, 31, 15, 56, 30, 825, DateTimeKind.Local).AddTicks(6371), new DateTime(2022, 3, 31, 15, 56, 30, 832, DateTimeKind.Local).AddTicks(4692) });

            migrationBuilder.UpdateData(
                table: "StatWidgetDisplayModeType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 3, 31, 15, 56, 30, 832, DateTimeKind.Local).AddTicks(6841), new DateTime(2022, 3, 31, 15, 56, 30, 832, DateTimeKind.Local).AddTicks(6891) });

            migrationBuilder.UpdateData(
                table: "StatWidgetDisplayModeType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 3, 31, 15, 56, 30, 832, DateTimeKind.Local).AddTicks(6934), new DateTime(2022, 3, 31, 15, 56, 30, 832, DateTimeKind.Local).AddTicks(6941) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 3, 31, 15, 56, 30, 839, DateTimeKind.Local).AddTicks(9893), new DateTime(2022, 3, 31, 15, 56, 30, 839, DateTimeKind.Local).AddTicks(9972) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 3, 31, 15, 56, 30, 840, DateTimeKind.Local).AddTicks(25), new DateTime(2022, 3, 31, 15, 56, 30, 840, DateTimeKind.Local).AddTicks(31) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 3, 31, 15, 56, 30, 840, DateTimeKind.Local).AddTicks(38), new DateTime(2022, 3, 31, 15, 56, 30, 840, DateTimeKind.Local).AddTicks(43) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 3, 31, 15, 56, 30, 840, DateTimeKind.Local).AddTicks(49), new DateTime(2022, 3, 31, 15, 56, 30, 840, DateTimeKind.Local).AddTicks(53) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 3, 31, 15, 56, 30, 840, DateTimeKind.Local).AddTicks(59), new DateTime(2022, 3, 31, 15, 56, 30, 840, DateTimeKind.Local).AddTicks(63) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 3, 31, 15, 56, 30, 840, DateTimeKind.Local).AddTicks(69), new DateTime(2022, 3, 31, 15, 56, 30, 840, DateTimeKind.Local).AddTicks(74) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 3, 31, 15, 56, 30, 840, DateTimeKind.Local).AddTicks(80), new DateTime(2022, 3, 31, 15, 56, 30, 840, DateTimeKind.Local).AddTicks(85) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 3, 31, 15, 56, 30, 840, DateTimeKind.Local).AddTicks(91), new DateTime(2022, 3, 31, 15, 56, 30, 840, DateTimeKind.Local).AddTicks(96) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 3, 31, 15, 56, 30, 840, DateTimeKind.Local).AddTicks(100), new DateTime(2022, 3, 31, 15, 56, 30, 840, DateTimeKind.Local).AddTicks(106) });

            migrationBuilder.UpdateData(
                table: "StatWidgetType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 3, 31, 15, 56, 30, 837, DateTimeKind.Local).AddTicks(2439), new DateTime(2022, 3, 31, 15, 56, 30, 837, DateTimeKind.Local).AddTicks(2508) });

            migrationBuilder.UpdateData(
                table: "StatWidgetType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 3, 31, 15, 56, 30, 837, DateTimeKind.Local).AddTicks(2566), new DateTime(2022, 3, 31, 15, 56, 30, 837, DateTimeKind.Local).AddTicks(2573) });

            migrationBuilder.UpdateData(
                table: "StatWidgetType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 3, 31, 15, 56, 30, 837, DateTimeKind.Local).AddTicks(2580), new DateTime(2022, 3, 31, 15, 56, 30, 837, DateTimeKind.Local).AddTicks(2586) });
        }
    }
}
