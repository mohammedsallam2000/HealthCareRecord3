using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class FKPatirntIdInPatientLab : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "PatientLab",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PatientLab_PatientId",
                table: "PatientLab",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientLab_Patients_PatientId",
                table: "PatientLab",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientLab_Patients_PatientId",
                table: "PatientLab");

            migrationBuilder.DropIndex(
                name: "IX_PatientLab_PatientId",
                table: "PatientLab");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "PatientLab");
        }
    }
}
