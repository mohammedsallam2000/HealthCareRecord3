using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddDailyDetectionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyDetection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    NurseId = table.Column<int>(type: "int", nullable: true),
                    DoctorId = table.Column<int>(type: "int", nullable: true),
                    EmplyeeId = table.Column<int>(type: "int", nullable: true),
                    LabId = table.Column<int>(type: "int", nullable: true),
                    RadiologyId = table.Column<int>(type: "int", nullable: true),
                    SurgeryId = table.Column<int>(type: "int", nullable: true),
                    MedicineId = table.Column<int>(type: "int", nullable: true),
                    RoomId = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    TreatmentId = table.Column<int>(type: "int", nullable: true),
                    AdminId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyDetection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyDetection_Admin_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyDetection_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyDetection_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyDetection_Emplyees_EmplyeeId",
                        column: x => x.EmplyeeId,
                        principalTable: "Emplyees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyDetection_Lab_LabId",
                        column: x => x.LabId,
                        principalTable: "Lab",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyDetection_Medicine_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyDetection_Nurses_NurseId",
                        column: x => x.NurseId,
                        principalTable: "Nurses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyDetection_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyDetection_Radiology_RadiologyId",
                        column: x => x.RadiologyId,
                        principalTable: "Radiology",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyDetection_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyDetection_Surgery_SurgeryId",
                        column: x => x.SurgeryId,
                        principalTable: "Surgery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyDetection_Treatment_TreatmentId",
                        column: x => x.TreatmentId,
                        principalTable: "Treatment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyDetection_AdminId",
                table: "DailyDetection",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyDetection_DepartmentId",
                table: "DailyDetection",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyDetection_DoctorId",
                table: "DailyDetection",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyDetection_EmplyeeId",
                table: "DailyDetection",
                column: "EmplyeeId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyDetection_LabId",
                table: "DailyDetection",
                column: "LabId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyDetection_MedicineId",
                table: "DailyDetection",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyDetection_NurseId",
                table: "DailyDetection",
                column: "NurseId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyDetection_PatientId",
                table: "DailyDetection",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyDetection_RadiologyId",
                table: "DailyDetection",
                column: "RadiologyId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyDetection_RoomId",
                table: "DailyDetection",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyDetection_SurgeryId",
                table: "DailyDetection",
                column: "SurgeryId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyDetection_TreatmentId",
                table: "DailyDetection",
                column: "TreatmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyDetection");
        }
    }
}
