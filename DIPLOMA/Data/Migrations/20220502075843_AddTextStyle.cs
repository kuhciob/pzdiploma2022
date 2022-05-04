using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DIPLOMA.Data.Migrations
{
    public partial class AddTextStyle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TextStyleID",
                table: "StatisticWidget",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TextStyleID",
                table: "MsgWidget",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TextStyleID",
                table: "FundraisingWidget",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TextStyle",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    TextColorHex = table.Column<string>(type: "nvarchar(7)", nullable: true, defaultValue: "#ffffff"),
                    Bold = table.Column<bool>(nullable: true, defaultValue: false),
                    Italic = table.Column<bool>(nullable: true, defaultValue: false),
                    Underline = table.Column<bool>(nullable: true, defaultValue: false),
                    LetterSpacing = table.Column<int>(nullable: true),
                    WordSpacing = table.Column<int>(nullable: true),
                    FontSize = table.Column<int>(nullable: true),
                    FontFamily = table.Column<string>(nullable: true),
                    Font = table.Column<string>(nullable: true),
                    AnimationName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextStyle", x => x.ID);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_StatisticWidget_TextStyleID",
                table: "StatisticWidget",
                column: "TextStyleID");

            migrationBuilder.CreateIndex(
                name: "IX_MsgWidget_TextStyleID",
                table: "MsgWidget",
                column: "TextStyleID");

            migrationBuilder.CreateIndex(
                name: "IX_FundraisingWidget_TextStyleID",
                table: "FundraisingWidget",
                column: "TextStyleID");

            migrationBuilder.AddForeignKey(
                name: "FK_FundraisingWidget_TextStyle_TextStyleID",
                table: "FundraisingWidget",
                column: "TextStyleID",
                principalTable: "TextStyle",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MsgWidget_TextStyle_TextStyleID",
                table: "MsgWidget",
                column: "TextStyleID",
                principalTable: "TextStyle",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StatisticWidget_TextStyle_TextStyleID",
                table: "StatisticWidget",
                column: "TextStyleID",
                principalTable: "TextStyle",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FundraisingWidget_TextStyle_TextStyleID",
                table: "FundraisingWidget");

            migrationBuilder.DropForeignKey(
                name: "FK_MsgWidget_TextStyle_TextStyleID",
                table: "MsgWidget");

            migrationBuilder.DropForeignKey(
                name: "FK_StatisticWidget_TextStyle_TextStyleID",
                table: "StatisticWidget");

            migrationBuilder.DropTable(
                name: "TextStyle");

            migrationBuilder.DropIndex(
                name: "IX_StatisticWidget_TextStyleID",
                table: "StatisticWidget");

            migrationBuilder.DropIndex(
                name: "IX_MsgWidget_TextStyleID",
                table: "MsgWidget");

            migrationBuilder.DropIndex(
                name: "IX_FundraisingWidget_TextStyleID",
                table: "FundraisingWidget");

            migrationBuilder.DropColumn(
                name: "TextStyleID",
                table: "StatisticWidget");

            migrationBuilder.DropColumn(
                name: "TextStyleID",
                table: "MsgWidget");

            migrationBuilder.DropColumn(
                name: "TextStyleID",
                table: "FundraisingWidget");

            migrationBuilder.UpdateData(
                table: "StatWidgetDirectionType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 1, 15, 55, 10, 68, DateTimeKind.Local).AddTicks(5852), new DateTime(2022, 5, 1, 15, 55, 10, 68, DateTimeKind.Local).AddTicks(5950) });

            migrationBuilder.UpdateData(
                table: "StatWidgetDirectionType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 1, 15, 55, 10, 68, DateTimeKind.Local).AddTicks(6741), new DateTime(2022, 5, 1, 15, 55, 10, 68, DateTimeKind.Local).AddTicks(6770) });

            migrationBuilder.UpdateData(
                table: "StatWidgetDirectionType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 1, 15, 55, 10, 68, DateTimeKind.Local).AddTicks(6811), new DateTime(2022, 5, 1, 15, 55, 10, 68, DateTimeKind.Local).AddTicks(6874) });

            migrationBuilder.UpdateData(
                table: "StatWidgetDirectionType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 1, 15, 55, 10, 68, DateTimeKind.Local).AddTicks(6895), new DateTime(2022, 5, 1, 15, 55, 10, 68, DateTimeKind.Local).AddTicks(6899) });

            migrationBuilder.UpdateData(
                table: "StatWidgetDisplayModeType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 1, 15, 55, 10, 53, DateTimeKind.Local).AddTicks(3687), new DateTime(2022, 5, 1, 15, 55, 10, 59, DateTimeKind.Local).AddTicks(5419) });

            migrationBuilder.UpdateData(
                table: "StatWidgetDisplayModeType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 1, 15, 55, 10, 59, DateTimeKind.Local).AddTicks(7246), new DateTime(2022, 5, 1, 15, 55, 10, 59, DateTimeKind.Local).AddTicks(7284) });

            migrationBuilder.UpdateData(
                table: "StatWidgetDisplayModeType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 1, 15, 55, 10, 59, DateTimeKind.Local).AddTicks(7327), new DateTime(2022, 5, 1, 15, 55, 10, 59, DateTimeKind.Local).AddTicks(7333) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 1, 15, 55, 10, 66, DateTimeKind.Local).AddTicks(198), new DateTime(2022, 5, 1, 15, 55, 10, 66, DateTimeKind.Local).AddTicks(272) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 1, 15, 55, 10, 66, DateTimeKind.Local).AddTicks(315), new DateTime(2022, 5, 1, 15, 55, 10, 66, DateTimeKind.Local).AddTicks(321) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 1, 15, 55, 10, 66, DateTimeKind.Local).AddTicks(327), new DateTime(2022, 5, 1, 15, 55, 10, 66, DateTimeKind.Local).AddTicks(331) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 1, 15, 55, 10, 66, DateTimeKind.Local).AddTicks(336), new DateTime(2022, 5, 1, 15, 55, 10, 66, DateTimeKind.Local).AddTicks(342) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 1, 15, 55, 10, 66, DateTimeKind.Local).AddTicks(347), new DateTime(2022, 5, 1, 15, 55, 10, 66, DateTimeKind.Local).AddTicks(353) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 1, 15, 55, 10, 66, DateTimeKind.Local).AddTicks(359), new DateTime(2022, 5, 1, 15, 55, 10, 66, DateTimeKind.Local).AddTicks(363) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 1, 15, 55, 10, 66, DateTimeKind.Local).AddTicks(369), new DateTime(2022, 5, 1, 15, 55, 10, 66, DateTimeKind.Local).AddTicks(375) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 1, 15, 55, 10, 66, DateTimeKind.Local).AddTicks(381), new DateTime(2022, 5, 1, 15, 55, 10, 66, DateTimeKind.Local).AddTicks(386) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 1, 15, 55, 10, 66, DateTimeKind.Local).AddTicks(392), new DateTime(2022, 5, 1, 15, 55, 10, 66, DateTimeKind.Local).AddTicks(397) });

            migrationBuilder.UpdateData(
                table: "StatWidgetType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 1, 15, 55, 10, 63, DateTimeKind.Local).AddTicks(5220), new DateTime(2022, 5, 1, 15, 55, 10, 63, DateTimeKind.Local).AddTicks(5303) });

            migrationBuilder.UpdateData(
                table: "StatWidgetType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 1, 15, 55, 10, 63, DateTimeKind.Local).AddTicks(5373), new DateTime(2022, 5, 1, 15, 55, 10, 63, DateTimeKind.Local).AddTicks(5385) });

            migrationBuilder.UpdateData(
                table: "StatWidgetType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 1, 15, 55, 10, 63, DateTimeKind.Local).AddTicks(5399), new DateTime(2022, 5, 1, 15, 55, 10, 63, DateTimeKind.Local).AddTicks(5412) });
        }
    }
}
