using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class EditsInDatabase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientLab_Patients_PatientId",
                table: "PatientLab");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientRediology_Patients_PatientId",
                table: "PatientRediology");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientRoom_Patients_PatientId",
                table: "PatientRoom");

            migrationBuilder.DropIndex(
                name: "IX_PatientRoom_PatientId",
                table: "PatientRoom");

            migrationBuilder.DropIndex(
                name: "IX_PatientRediology_PatientId",
                table: "PatientRediology");

            migrationBuilder.DropIndex(
                name: "IX_PatientLab_PatientId",
                table: "PatientLab");

            migrationBuilder.DropColumn(
                name: "LogOutTime",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "PatientRoom");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "PatientRediology");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "PatientLab");

            migrationBuilder.DropColumn(
                name: "AnotherPhone",
                table: "Nurses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LogOutTime",
                table: "Patients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "PatientRoom",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "PatientRediology",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "PatientLab",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AnotherPhone",
                table: "Nurses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PatientRoom_PatientId",
                table: "PatientRoom",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientRediology_PatientId",
                table: "PatientRediology",
                column: "PatientId");

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
                name: "FK_PatientRediology_Patients_PatientId",
                table: "PatientRediology",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientRoom_Patients_PatientId",
                table: "PatientRoom",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
