using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class EditsInDatabase3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientSurgery_Patients_PatientId",
                table: "PatientSurgery");

            migrationBuilder.DropForeignKey(
                name: "FK_Treatment_Patients_PatientId",
                table: "Treatment");

            migrationBuilder.DropTable(
                name: "PatientOfDoctor");

            migrationBuilder.DropTable(
                name: "PatientOfNurse");

            migrationBuilder.DropIndex(
                name: "IX_Treatment_PatientId",
                table: "Treatment");

            migrationBuilder.DropIndex(
                name: "IX_PatientSurgery_PatientId",
                table: "PatientSurgery");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "PatientSurgery");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Treatment",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "PatientSurgery",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PatientOfDoctor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    TreatmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientOfDoctor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientOfDoctor_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientOfDoctor_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientOfDoctor_Treatment_TreatmentId",
                        column: x => x.TreatmentId,
                        principalTable: "Treatment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientOfNurse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NurseId = table.Column<int>(type: "int", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientOfNurse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientOfNurse_Nurses_NurseId",
                        column: x => x.NurseId,
                        principalTable: "Nurses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientOfNurse_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Treatment_PatientId",
                table: "Treatment",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientSurgery_PatientId",
                table: "PatientSurgery",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientOfDoctor_DoctorId",
                table: "PatientOfDoctor",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientOfDoctor_PatientId",
                table: "PatientOfDoctor",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientOfDoctor_TreatmentId",
                table: "PatientOfDoctor",
                column: "TreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientOfNurse_NurseId",
                table: "PatientOfNurse",
                column: "NurseId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientOfNurse_PatientId",
                table: "PatientOfNurse",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientSurgery_Patients_PatientId",
                table: "PatientSurgery",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Treatment_Patients_PatientId",
                table: "Treatment",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
