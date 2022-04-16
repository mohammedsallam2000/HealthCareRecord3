using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class OrderDateAndTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateAndTime",
                table: "PatientRediology",
                newName: "OrderDateAndTime");

            migrationBuilder.RenameColumn(
                name: "DateAndTime",
                table: "PatientLab",
                newName: "OrderDateAndTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderDateAndTime",
                table: "PatientRediology",
                newName: "DateAndTime");

            migrationBuilder.RenameColumn(
                name: "OrderDateAndTime",
                table: "PatientLab",
                newName: "DateAndTime");
        }
    }
}
