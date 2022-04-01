using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DIPLOMA.Data.Migrations
{
    public partial class AddStatisticWidget : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StatWidgetDirectionType",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    CD = table.Column<string>(maxLength: 2, nullable: true),
                    Description = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatWidgetDirectionType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StatWidgetDisplayModeType",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    CD = table.Column<string>(maxLength: 2, nullable: true),
                    Description = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatWidgetDisplayModeType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StatWidgetTimeIntervalType",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    CD = table.Column<string>(maxLength: 2, nullable: true),
                    Description = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatWidgetTimeIntervalType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StatWidgetType",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    CD = table.Column<string>(maxLength: 2, nullable: true),
                    Description = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatWidgetType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StatisticWidget",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Url = table.Column<string>(maxLength: 2000, nullable: true),
                    HeaderText = table.Column<string>(nullable: true),
                    ElementsCount = table.Column<int>(nullable: false, defaultValue: 5),
                    ScrollingSpeed = table.Column<int>(nullable: false),
                    DisplayModeID = table.Column<int>(nullable: false),
                    WidgetTypeID = table.Column<int>(nullable: false),
                    DirectionID = table.Column<int>(nullable: false),
                    TimeIntervalID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatisticWidget", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StatisticWidget_StatWidgetDirectionType_DirectionID",
                        column: x => x.DirectionID,
                        principalTable: "StatWidgetDirectionType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StatisticWidget_StatWidgetDisplayModeType_DisplayModeID",
                        column: x => x.DisplayModeID,
                        principalTable: "StatWidgetDisplayModeType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StatisticWidget_StatWidgetTimeIntervalType_TimeIntervalID",
                        column: x => x.TimeIntervalID,
                        principalTable: "StatWidgetTimeIntervalType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__StatisticWidget_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StatisticWidget_StatWidgetType_WidgetTypeID",
                        column: x => x.WidgetTypeID,
                        principalTable: "StatWidgetType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "StatWidgetDirectionType",
                columns: new[] { "ID", "CD", "CreatedDate", "Description", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "RL", new DateTime(2022, 3, 29, 17, 31, 27, 161, DateTimeKind.Local).AddTicks(7198), "Right -> Left", new DateTime(2022, 3, 29, 17, 31, 27, 161, DateTimeKind.Local).AddTicks(7266) },
                    { 2, "LR", new DateTime(2022, 3, 29, 17, 31, 27, 161, DateTimeKind.Local).AddTicks(7308), "Left -> Right", new DateTime(2022, 3, 29, 17, 31, 27, 161, DateTimeKind.Local).AddTicks(7315) },
                    { 3, "TB", new DateTime(2022, 3, 29, 17, 31, 27, 161, DateTimeKind.Local).AddTicks(7322), "Top -> Bottom", new DateTime(2022, 3, 29, 17, 31, 27, 161, DateTimeKind.Local).AddTicks(7328) },
                    { 4, "BT", new DateTime(2022, 3, 29, 17, 31, 27, 161, DateTimeKind.Local).AddTicks(7334), "Bottom -> Top", new DateTime(2022, 3, 29, 17, 31, 27, 161, DateTimeKind.Local).AddTicks(7340) }
                });

            migrationBuilder.InsertData(
                table: "StatWidgetDisplayModeType",
                columns: new[] { "ID", "CD", "CreatedDate", "Description", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "LL", new DateTime(2022, 3, 29, 17, 31, 27, 146, DateTimeKind.Local).AddTicks(2682), "List", new DateTime(2022, 3, 29, 17, 31, 27, 154, DateTimeKind.Local).AddTicks(1930) },
                    { 2, "CL", new DateTime(2022, 3, 29, 17, 31, 27, 154, DateTimeKind.Local).AddTicks(3473), "Сreeping line", new DateTime(2022, 3, 29, 17, 31, 27, 154, DateTimeKind.Local).AddTicks(3509) },
                    { 3, "SL", new DateTime(2022, 3, 29, 17, 31, 27, 154, DateTimeKind.Local).AddTicks(3553), "Slider", new DateTime(2022, 3, 29, 17, 31, 27, 154, DateTimeKind.Local).AddTicks(3561) }
                });

            migrationBuilder.InsertData(
                table: "StatWidgetTimeIntervalType",
                columns: new[] { "ID", "CD", "CreatedDate", "Description", "UpdatedDate" },
                values: new object[,]
                {
                    { 9, "24", new DateTime(2022, 3, 29, 17, 31, 27, 159, DateTimeKind.Local).AddTicks(5892), "Last 24 hours", new DateTime(2022, 3, 29, 17, 31, 27, 159, DateTimeKind.Local).AddTicks(5899) },
                    { 8, "LY", new DateTime(2022, 3, 29, 17, 31, 27, 159, DateTimeKind.Local).AddTicks(5880), "Last year", new DateTime(2022, 3, 29, 17, 31, 27, 159, DateTimeKind.Local).AddTicks(5886) },
                    { 7, "TY", new DateTime(2022, 3, 29, 17, 31, 27, 159, DateTimeKind.Local).AddTicks(5866), "This year", new DateTime(2022, 3, 29, 17, 31, 27, 159, DateTimeKind.Local).AddTicks(5873) },
                    { 6, "30", new DateTime(2022, 3, 29, 17, 31, 27, 159, DateTimeKind.Local).AddTicks(5853), "Last 30 Days", new DateTime(2022, 3, 29, 17, 31, 27, 159, DateTimeKind.Local).AddTicks(5859) },
                    { 3, "TW", new DateTime(2022, 3, 29, 17, 31, 27, 159, DateTimeKind.Local).AddTicks(5814), "This week", new DateTime(2022, 3, 29, 17, 31, 27, 159, DateTimeKind.Local).AddTicks(5820) },
                    { 4, "7D", new DateTime(2022, 3, 29, 17, 31, 27, 159, DateTimeKind.Local).AddTicks(5827), "Last 7 days", new DateTime(2022, 3, 29, 17, 31, 27, 159, DateTimeKind.Local).AddTicks(5834) },
                    { 2, "AT", new DateTime(2022, 3, 29, 17, 31, 27, 159, DateTimeKind.Local).AddTicks(5801), "All time", new DateTime(2022, 3, 29, 17, 31, 27, 159, DateTimeKind.Local).AddTicks(5807) },
                    { 1, "TD", new DateTime(2022, 3, 29, 17, 31, 27, 159, DateTimeKind.Local).AddTicks(5713), "Today", new DateTime(2022, 3, 29, 17, 31, 27, 159, DateTimeKind.Local).AddTicks(5766) },
                    { 5, "TM", new DateTime(2022, 3, 29, 17, 31, 27, 159, DateTimeKind.Local).AddTicks(5840), "This month", new DateTime(2022, 3, 29, 17, 31, 27, 159, DateTimeKind.Local).AddTicks(5847) }
                });

            migrationBuilder.InsertData(
                table: "StatWidgetType",
                columns: new[] { "ID", "CD", "CreatedDate", "Description", "UpdatedDate" },
                values: new object[,]
                {
                    { 2, "LD", new DateTime(2022, 3, 29, 17, 31, 27, 157, DateTimeKind.Local).AddTicks(7944), "Last Donater", new DateTime(2022, 3, 29, 17, 31, 27, 157, DateTimeKind.Local).AddTicks(7951) },
                    { 1, "TP", new DateTime(2022, 3, 29, 17, 31, 27, 157, DateTimeKind.Local).AddTicks(7831), "Top", new DateTime(2022, 3, 29, 17, 31, 27, 157, DateTimeKind.Local).AddTicks(7895) },
                    { 3, "CA", new DateTime(2022, 3, 29, 17, 31, 27, 157, DateTimeKind.Local).AddTicks(7958), "Collected  amount", new DateTime(2022, 3, 29, 17, 31, 27, 157, DateTimeKind.Local).AddTicks(7964) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StatisticWidget_DirectionID",
                table: "StatisticWidget",
                column: "DirectionID");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticWidget_DisplayModeID",
                table: "StatisticWidget",
                column: "DisplayModeID");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticWidget_TimeIntervalID",
                table: "StatisticWidget",
                column: "TimeIntervalID");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticWidget_UserID",
                table: "StatisticWidget",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_StatisticWidget_WidgetTypeID",
                table: "StatisticWidget",
                column: "WidgetTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StatisticWidget");

            migrationBuilder.DropTable(
                name: "StatWidgetDirectionType");

            migrationBuilder.DropTable(
                name: "StatWidgetDisplayModeType");

            migrationBuilder.DropTable(
                name: "StatWidgetTimeIntervalType");

            migrationBuilder.DropTable(
                name: "StatWidgetType");
        }
    }
}
