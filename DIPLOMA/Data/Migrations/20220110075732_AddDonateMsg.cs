using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DIPLOMA.Data.Migrations
{
    public partial class AddDonateMsg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DonateMsg",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    DonatorName = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonateMsg", x => x.ID);
                    table.ForeignKey(
                        name: "FK__DonateMsg_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonateMsg_UserID",
                table: "DonateMsg",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonateMsg");
        }
    }
}
