using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class DateAndTimeInPatientSurgery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Time",
                table: "PatientSurgery",
                newName: "OrderDateAndTime");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "PatientSurgery",
                newName: "DoneDateAndTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderDateAndTime",
                table: "PatientSurgery",
                newName: "Time");

            migrationBuilder.RenameColumn(
                name: "DoneDateAndTime",
                table: "PatientSurgery",
                newName: "Date");
        }
    }
}
