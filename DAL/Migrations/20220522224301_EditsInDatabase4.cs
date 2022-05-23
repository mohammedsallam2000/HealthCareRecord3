using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class EditsInDatabase4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientMedicine_Doctors_DoctorId",
                table: "PatientMedicine");

            migrationBuilder.DropIndex(
                name: "IX_PatientMedicine_DoctorId",
                table: "PatientMedicine");

            migrationBuilder.DropColumn(
                name: "DateAndTime",
                table: "PatientMedicine");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "PatientMedicine");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DateAndTime",
                table: "PatientMedicine",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "PatientMedicine",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicine_DoctorId",
                table: "PatientMedicine",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientMedicine_Doctors_DoctorId",
                table: "PatientMedicine",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
