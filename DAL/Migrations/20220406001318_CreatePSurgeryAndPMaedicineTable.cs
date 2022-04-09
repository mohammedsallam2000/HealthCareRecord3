using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class CreatePSurgeryAndPMaedicineTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Surgery_Doctors_DoctorId",
                table: "Surgery");

            migrationBuilder.DropForeignKey(
                name: "FK_Surgery_Nurses_NurseId",
                table: "Surgery");

            migrationBuilder.DropForeignKey(
                name: "FK_Surgery_Patients_PatientId",
                table: "Surgery");

            migrationBuilder.DropIndex(
                name: "IX_Surgery_DoctorId",
                table: "Surgery");

            migrationBuilder.DropIndex(
                name: "IX_Surgery_NurseId",
                table: "Surgery");

            migrationBuilder.DropIndex(
                name: "IX_Surgery_PatientId",
                table: "Surgery");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Surgery");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Surgery");

            migrationBuilder.DropColumn(
                name: "NurseId",
                table: "Surgery");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Surgery");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Surgery");

            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "Room",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "Radiology",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "PatientRoom",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "Medicine",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "Lab",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "PatientMedicine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    DateAndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    DoctorId = table.Column<int>(type: "int", nullable: true),
                    MedicineId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientMedicine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientMedicine_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientMedicine_Medicine_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientMedicine_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientSurgery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    DoctorId = table.Column<int>(type: "int", nullable: true),
                    NurseId = table.Column<int>(type: "int", nullable: true),
                    SurgeryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientSurgery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientSurgery_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientSurgery_Nurses_NurseId",
                        column: x => x.NurseId,
                        principalTable: "Nurses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientSurgery_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientSurgery_Surgery_SurgeryId",
                        column: x => x.SurgeryId,
                        principalTable: "Surgery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicine_DoctorId",
                table: "PatientMedicine",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicine_MedicineId",
                table: "PatientMedicine",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicine_PatientId",
                table: "PatientMedicine",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientSurgery_DoctorId",
                table: "PatientSurgery",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientSurgery_NurseId",
                table: "PatientSurgery",
                column: "NurseId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientSurgery_PatientId",
                table: "PatientSurgery",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientSurgery_SurgeryId",
                table: "PatientSurgery",
                column: "SurgeryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientMedicine");

            migrationBuilder.DropTable(
                name: "PatientSurgery");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Radiology");

            migrationBuilder.DropColumn(
                name: "State",
                table: "PatientRoom");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Medicine");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Lab");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Surgery",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Surgery",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NurseId",
                table: "Surgery",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Surgery",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "Surgery",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Surgery_DoctorId",
                table: "Surgery",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Surgery_NurseId",
                table: "Surgery",
                column: "NurseId");

            migrationBuilder.CreateIndex(
                name: "IX_Surgery_PatientId",
                table: "Surgery",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Surgery_Doctors_DoctorId",
                table: "Surgery",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Surgery_Nurses_NurseId",
                table: "Surgery",
                column: "NurseId",
                principalTable: "Nurses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Surgery_Patients_PatientId",
                table: "Surgery",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
