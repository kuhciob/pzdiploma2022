using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DIPLOMA.Data.Migrations
{
    public partial class NullForBoolsAndTargetAmtType : Migration
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
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "ReadHeader",
                table: "MsgWidget",
                nullable: true,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "RandomContent",
                table: "MsgWidget",
                nullable: true,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<decimal>(
                name: "TargetAmt",
                table: "FundraisingWidget",
                type: "decimal(18, 4)",
                nullable: true,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true,
                oldDefaultValue: 0m);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "ReadMessage",
                table: "MsgWidget",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldNullable: true,
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "ReadHeader",
                table: "MsgWidget",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldNullable: true,
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "RandomContent",
                table: "MsgWidget",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldNullable: true,
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<decimal>(
                name: "TargetAmt",
                table: "FundraisingWidget",
                type: "decimal(18,2)",
                nullable: true,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 4)",
                oldNullable: true,
                oldDefaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "StatWidgetDirectionType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 1, 15, 50, 28, 664, DateTimeKind.Local).AddTicks(5400), new DateTime(2022, 5, 1, 15, 50, 28, 664, DateTimeKind.Local).AddTicks(5478) });

            migrationBuilder.UpdateData(
                table: "StatWidgetDirectionType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 1, 15, 50, 28, 664, DateTimeKind.Local).AddTicks(6095), new DateTime(2022, 5, 1, 15, 50, 28, 664, DateTimeKind.Local).AddTicks(6120) });

            migrationBuilder.UpdateData(
                table: "StatWidgetDirectionType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 1, 15, 50, 28, 664, DateTimeKind.Local).AddTicks(6145), new DateTime(2022, 5, 1, 15, 50, 28, 664, DateTimeKind.Local).AddTicks(6152) });

            migrationBuilder.UpdateData(
                table: "StatWidgetDirectionType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 1, 15, 50, 28, 664, DateTimeKind.Local).AddTicks(6161), new DateTime(2022, 5, 1, 15, 50, 28, 664, DateTimeKind.Local).AddTicks(6167) });

            migrationBuilder.UpdateData(
                table: "StatWidgetDisplayModeType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 1, 15, 50, 28, 652, DateTimeKind.Local).AddTicks(3214), new DateTime(2022, 5, 1, 15, 50, 28, 657, DateTimeKind.Local).AddTicks(2794) });

            migrationBuilder.UpdateData(
                table: "StatWidgetDisplayModeType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 1, 15, 50, 28, 657, DateTimeKind.Local).AddTicks(4407), new DateTime(2022, 5, 1, 15, 50, 28, 657, DateTimeKind.Local).AddTicks(4439) });

            migrationBuilder.UpdateData(
                table: "StatWidgetDisplayModeType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 1, 15, 50, 28, 657, DateTimeKind.Local).AddTicks(4481), new DateTime(2022, 5, 1, 15, 50, 28, 657, DateTimeKind.Local).AddTicks(4488) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 1, 15, 50, 28, 662, DateTimeKind.Local).AddTicks(8967), new DateTime(2022, 5, 1, 15, 50, 28, 662, DateTimeKind.Local).AddTicks(9037) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 1, 15, 50, 28, 662, DateTimeKind.Local).AddTicks(9076), new DateTime(2022, 5, 1, 15, 50, 28, 662, DateTimeKind.Local).AddTicks(9082) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 1, 15, 50, 28, 662, DateTimeKind.Local).AddTicks(9088), new DateTime(2022, 5, 1, 15, 50, 28, 662, DateTimeKind.Local).AddTicks(9092) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 1, 15, 50, 28, 662, DateTimeKind.Local).AddTicks(9097), new DateTime(2022, 5, 1, 15, 50, 28, 662, DateTimeKind.Local).AddTicks(9101) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 1, 15, 50, 28, 662, DateTimeKind.Local).AddTicks(9107), new DateTime(2022, 5, 1, 15, 50, 28, 662, DateTimeKind.Local).AddTicks(9111) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 1, 15, 50, 28, 662, DateTimeKind.Local).AddTicks(9116), new DateTime(2022, 5, 1, 15, 50, 28, 662, DateTimeKind.Local).AddTicks(9120) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 1, 15, 50, 28, 662, DateTimeKind.Local).AddTicks(9125), new DateTime(2022, 5, 1, 15, 50, 28, 662, DateTimeKind.Local).AddTicks(9129) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 1, 15, 50, 28, 662, DateTimeKind.Local).AddTicks(9134), new DateTime(2022, 5, 1, 15, 50, 28, 662, DateTimeKind.Local).AddTicks(9138) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 1, 15, 50, 28, 662, DateTimeKind.Local).AddTicks(9143), new DateTime(2022, 5, 1, 15, 50, 28, 662, DateTimeKind.Local).AddTicks(9149) });

            migrationBuilder.UpdateData(
                table: "StatWidgetType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 1, 15, 50, 28, 661, DateTimeKind.Local).AddTicks(6), new DateTime(2022, 5, 1, 15, 50, 28, 661, DateTimeKind.Local).AddTicks(82) });

            migrationBuilder.UpdateData(
                table: "StatWidgetType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 1, 15, 50, 28, 661, DateTimeKind.Local).AddTicks(129), new DateTime(2022, 5, 1, 15, 50, 28, 661, DateTimeKind.Local).AddTicks(136) });

            migrationBuilder.UpdateData(
                table: "StatWidgetType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 5, 1, 15, 50, 28, 661, DateTimeKind.Local).AddTicks(144), new DateTime(2022, 5, 1, 15, 50, 28, 661, DateTimeKind.Local).AddTicks(150) });
        }
    }
}
