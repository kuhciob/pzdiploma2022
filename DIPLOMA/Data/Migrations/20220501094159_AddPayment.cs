using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DIPLOMA.Data.Migrations
{
    public partial class AddPayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CheckoutSessionID",
                table: "DonateMsg",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CheckoutSessionSucceed",
                table: "DonateMsg",
                nullable: false,
                defaultValue: false);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckoutSessionID",
                table: "DonateMsg");

            migrationBuilder.DropColumn(
                name: "CheckoutSessionSucceed",
                table: "DonateMsg");
        }
    }
}
