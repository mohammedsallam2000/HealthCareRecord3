using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class TreatmentOrderDateAndDoneDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateAndTime",
                table: "Treatment",
                newName: "OrderDateAndTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "DoneDateAndTime",
                table: "Treatment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoneDateAndTime",
                table: "Treatment");

            migrationBuilder.RenameColumn(
                name: "OrderDateAndTime",
                table: "Treatment",
                newName: "DateAndTime");
        }
    }
}
