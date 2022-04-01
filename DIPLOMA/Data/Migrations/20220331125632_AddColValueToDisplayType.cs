using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DIPLOMA.Data.Migrations
{
    public partial class AddColValueToDisplayType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "StatWidgetDirectionType",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DonatorName",
                table: "DonateMsg",
                defaultValue: "",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "StatWidgetDirectionType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate", "Value" },
                values: new object[] { new DateTime(2022, 3, 31, 15, 56, 30, 842, DateTimeKind.Local).AddTicks(1065), new DateTime(2022, 3, 31, 15, 56, 30, 842, DateTimeKind.Local).AddTicks(1132), "left" });

            migrationBuilder.UpdateData(
                table: "StatWidgetDirectionType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate", "Value" },
                values: new object[] { new DateTime(2022, 3, 31, 15, 56, 30, 842, DateTimeKind.Local).AddTicks(1762), new DateTime(2022, 3, 31, 15, 56, 30, 842, DateTimeKind.Local).AddTicks(1781), "right" });

            migrationBuilder.UpdateData(
                table: "StatWidgetDirectionType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate", "Value" },
                values: new object[] { new DateTime(2022, 3, 31, 15, 56, 30, 842, DateTimeKind.Local).AddTicks(1802), new DateTime(2022, 3, 31, 15, 56, 30, 842, DateTimeKind.Local).AddTicks(1808), "down" });

            migrationBuilder.UpdateData(
                table: "StatWidgetDirectionType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate", "Value" },
                values: new object[] { new DateTime(2022, 3, 31, 15, 56, 30, 842, DateTimeKind.Local).AddTicks(1815), new DateTime(2022, 3, 31, 15, 56, 30, 842, DateTimeKind.Local).AddTicks(1820), "up" });

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
                columns: new[] { "CD", "CreatedDate", "Description", "UpdatedDate" },
                values: new object[] { "TM", new DateTime(2022, 3, 31, 15, 56, 30, 840, DateTimeKind.Local).AddTicks(59), "This month", new DateTime(2022, 3, 31, 15, 56, 30, 840, DateTimeKind.Local).AddTicks(63) });

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
                columns: new[] { "CreatedDate", "Description", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 3, 31, 15, 56, 30, 840, DateTimeKind.Local).AddTicks(80), "This Year", new DateTime(2022, 3, 31, 15, 56, 30, 840, DateTimeKind.Local).AddTicks(85) });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "StatWidgetDirectionType");

            migrationBuilder.AlterColumn<string>(
                name: "DonatorName",
                table: "DonateMsg",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "StatWidgetDirectionType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 3, 29, 17, 31, 27, 161, DateTimeKind.Local).AddTicks(7198), new DateTime(2022, 3, 29, 17, 31, 27, 161, DateTimeKind.Local).AddTicks(7266) });

            migrationBuilder.UpdateData(
                table: "StatWidgetDirectionType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 3, 29, 17, 31, 27, 161, DateTimeKind.Local).AddTicks(7308), new DateTime(2022, 3, 29, 17, 31, 27, 161, DateTimeKind.Local).AddTicks(7315) });

            migrationBuilder.UpdateData(
                table: "StatWidgetDirectionType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 3, 29, 17, 31, 27, 161, DateTimeKind.Local).AddTicks(7322), new DateTime(2022, 3, 29, 17, 31, 27, 161, DateTimeKind.Local).AddTicks(7328) });

            migrationBuilder.UpdateData(
                table: "StatWidgetDirectionType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 3, 29, 17, 31, 27, 161, DateTimeKind.Local).AddTicks(7334), new DateTime(2022, 3, 29, 17, 31, 27, 161, DateTimeKind.Local).AddTicks(7340) });

            migrationBuilder.UpdateData(
                table: "StatWidgetDisplayModeType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 3, 29, 17, 31, 27, 146, DateTimeKind.Local).AddTicks(2682), new DateTime(2022, 3, 29, 17, 31, 27, 154, DateTimeKind.Local).AddTicks(1930) });

            migrationBuilder.UpdateData(
                table: "StatWidgetDisplayModeType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 3, 29, 17, 31, 27, 154, DateTimeKind.Local).AddTicks(3473), new DateTime(2022, 3, 29, 17, 31, 27, 154, DateTimeKind.Local).AddTicks(3509) });

            migrationBuilder.UpdateData(
                table: "StatWidgetDisplayModeType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 3, 29, 17, 31, 27, 154, DateTimeKind.Local).AddTicks(3553), new DateTime(2022, 3, 29, 17, 31, 27, 154, DateTimeKind.Local).AddTicks(3561) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 3, 29, 17, 31, 27, 159, DateTimeKind.Local).AddTicks(5713), new DateTime(2022, 3, 29, 17, 31, 27, 159, DateTimeKind.Local).AddTicks(5766) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 3, 29, 17, 31, 27, 159, DateTimeKind.Local).AddTicks(5801), new DateTime(2022, 3, 29, 17, 31, 27, 159, DateTimeKind.Local).AddTicks(5807) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 3, 29, 17, 31, 27, 159, DateTimeKind.Local).AddTicks(5814), new DateTime(2022, 3, 29, 17, 31, 27, 159, DateTimeKind.Local).AddTicks(5820) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 3, 29, 17, 31, 27, 159, DateTimeKind.Local).AddTicks(5827), new DateTime(2022, 3, 29, 17, 31, 27, 159, DateTimeKind.Local).AddTicks(5834) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CD", "CreatedDate", "Description", "UpdatedDate" },
                values: new object[] { "LM", new DateTime(2022, 3, 29, 17, 31, 27, 159, DateTimeKind.Local).AddTicks(5840), "Last month", new DateTime(2022, 3, 29, 17, 31, 27, 159, DateTimeKind.Local).AddTicks(5847) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 3, 29, 17, 31, 27, 159, DateTimeKind.Local).AddTicks(5853), new DateTime(2022, 3, 29, 17, 31, 27, 159, DateTimeKind.Local).AddTicks(5859) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDate", "Description", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 3, 29, 17, 31, 27, 159, DateTimeKind.Local).AddTicks(5866), "ThisYear", new DateTime(2022, 3, 29, 17, 31, 27, 159, DateTimeKind.Local).AddTicks(5873) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 3, 29, 17, 31, 27, 159, DateTimeKind.Local).AddTicks(5880), new DateTime(2022, 3, 29, 17, 31, 27, 159, DateTimeKind.Local).AddTicks(5886) });

            migrationBuilder.UpdateData(
                table: "StatWidgetTimeIntervalType",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 3, 29, 17, 31, 27, 159, DateTimeKind.Local).AddTicks(5892), new DateTime(2022, 3, 29, 17, 31, 27, 159, DateTimeKind.Local).AddTicks(5899) });

            migrationBuilder.UpdateData(
                table: "StatWidgetType",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 3, 29, 17, 31, 27, 157, DateTimeKind.Local).AddTicks(7831), new DateTime(2022, 3, 29, 17, 31, 27, 157, DateTimeKind.Local).AddTicks(7895) });

            migrationBuilder.UpdateData(
                table: "StatWidgetType",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 3, 29, 17, 31, 27, 157, DateTimeKind.Local).AddTicks(7944), new DateTime(2022, 3, 29, 17, 31, 27, 157, DateTimeKind.Local).AddTicks(7951) });

            migrationBuilder.UpdateData(
                table: "StatWidgetType",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 3, 29, 17, 31, 27, 157, DateTimeKind.Local).AddTicks(7958), new DateTime(2022, 3, 29, 17, 31, 27, 157, DateTimeKind.Local).AddTicks(7964) });
        }
    }
}
