using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class _4a4a4a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientLab_Patients_PatientId",
                table: "PatientLab");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientMedicine_DailyDetection_DailyDetectionId",
                table: "PatientMedicine");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientMedicine_Patients_PatientId",
                table: "PatientMedicine");

            migrationBuilder.DropIndex(
                name: "IX_PatientMedicine_DailyDetectionId",
                table: "PatientMedicine");

            migrationBuilder.DropIndex(
                name: "IX_PatientLab_PatientId",
                table: "PatientLab");

            migrationBuilder.DropColumn(
                name: "DailyDetectionId",
                table: "PatientMedicine");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "PatientLab");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "PatientMedicine",
                newName: "TreatmentId");

            migrationBuilder.RenameIndex(
                name: "IX_PatientMedicine_PatientId",
                table: "PatientMedicine",
                newName: "IX_PatientMedicine_TreatmentId");

            migrationBuilder.AlterColumn<string>(
                name: "DateAndTime",
                table: "PatientMedicine",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "DoneDateAndTime",
                table: "PatientLab",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_PatientMedicine_Treatment_TreatmentId",
                table: "PatientMedicine",
                column: "TreatmentId",
                principalTable: "Treatment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientMedicine_Treatment_TreatmentId",
                table: "PatientMedicine");

            migrationBuilder.DropColumn(
                name: "DoneDateAndTime",
                table: "PatientLab");

            migrationBuilder.RenameColumn(
                name: "TreatmentId",
                table: "PatientMedicine",
                newName: "PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_PatientMedicine_TreatmentId",
                table: "PatientMedicine",
                newName: "IX_PatientMedicine_PatientId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAndTime",
                table: "PatientMedicine",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DailyDetectionId",
                table: "PatientMedicine",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "PatientLab",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicine_DailyDetectionId",
                table: "PatientMedicine",
                column: "DailyDetectionId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_PatientMedicine_DailyDetection_DailyDetectionId",
                table: "PatientMedicine",
                column: "DailyDetectionId",
                principalTable: "DailyDetection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientMedicine_Patients_PatientId",
                table: "PatientMedicine",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
