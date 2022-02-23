using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class CreatHCRDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShiftId",
                table: "Nurses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShiftIdId",
                table: "Nurses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShiftId",
                table: "Emplyees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShiftIdId",
                table: "Emplyees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShiftId",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShiftIdId",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Lab",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lab", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientOfNurse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    NurseId = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Radiology",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radiology", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartShift = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndShift = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Surgery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    NurseId = table.Column<int>(type: "int", nullable: true),
                    DoctorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surgery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Surgery_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Surgery_Nurses_NurseId",
                        column: x => x.NurseId,
                        principalTable: "Nurses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Surgery_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientLab",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    DateAndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    DoctorId = table.Column<int>(type: "int", nullable: true),
                    LabId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientLab", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientLab_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientLab_Lab_LabId",
                        column: x => x.LabId,
                        principalTable: "Lab",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientLab_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Treatment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    DateAndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    MedicineId = table.Column<int>(type: "int", nullable: true),
                    DoctorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Treatment_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Treatment_Medicine_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Treatment_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientRediology",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    DateAndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    DoctorId = table.Column<int>(type: "int", nullable: true),
                    RadiologyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientRediology", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientRediology_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientRediology_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientRediology_Radiology_RadiologyId",
                        column: x => x.RadiologyId,
                        principalTable: "Radiology",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientRoom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    RoomId = table.Column<int>(type: "int", nullable: true),
                    NurseId = table.Column<int>(type: "int", nullable: true),
                    DoctorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientRoom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientRoom_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientRoom_Nurses_NurseId",
                        column: x => x.NurseId,
                        principalTable: "Nurses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientRoom_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientRoom_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientOfDoctor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    DoctorId = table.Column<int>(type: "int", nullable: true),
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

            migrationBuilder.CreateIndex(
                name: "IX_Nurses_ShiftIdId",
                table: "Nurses",
                column: "ShiftIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Emplyees_ShiftIdId",
                table: "Emplyees",
                column: "ShiftIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_ShiftIdId",
                table: "Doctors",
                column: "ShiftIdId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientLab_DoctorId",
                table: "PatientLab",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientLab_LabId",
                table: "PatientLab",
                column: "LabId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientLab_PatientId",
                table: "PatientLab",
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

            migrationBuilder.CreateIndex(
                name: "IX_PatientRediology_DoctorId",
                table: "PatientRediology",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientRediology_PatientId",
                table: "PatientRediology",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientRediology_RadiologyId",
                table: "PatientRediology",
                column: "RadiologyId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientRoom_DoctorId",
                table: "PatientRoom",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientRoom_NurseId",
                table: "PatientRoom",
                column: "NurseId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientRoom_PatientId",
                table: "PatientRoom",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientRoom_RoomId",
                table: "PatientRoom",
                column: "RoomId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Treatment_DoctorId",
                table: "Treatment",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatment_MedicineId",
                table: "Treatment",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatment_PatientId",
                table: "Treatment",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Shifts_ShiftIdId",
                table: "Doctors",
                column: "ShiftIdId",
                principalTable: "Shifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Emplyees_Shifts_ShiftIdId",
                table: "Emplyees",
                column: "ShiftIdId",
                principalTable: "Shifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Nurses_Shifts_ShiftIdId",
                table: "Nurses",
                column: "ShiftIdId",
                principalTable: "Shifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Shifts_ShiftIdId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Emplyees_Shifts_ShiftIdId",
                table: "Emplyees");

            migrationBuilder.DropForeignKey(
                name: "FK_Nurses_Shifts_ShiftIdId",
                table: "Nurses");

            migrationBuilder.DropTable(
                name: "PatientLab");

            migrationBuilder.DropTable(
                name: "PatientOfDoctor");

            migrationBuilder.DropTable(
                name: "PatientOfNurse");

            migrationBuilder.DropTable(
                name: "PatientRediology");

            migrationBuilder.DropTable(
                name: "PatientRoom");

            migrationBuilder.DropTable(
                name: "Shifts");

            migrationBuilder.DropTable(
                name: "Surgery");

            migrationBuilder.DropTable(
                name: "Lab");

            migrationBuilder.DropTable(
                name: "Treatment");

            migrationBuilder.DropTable(
                name: "Radiology");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Medicine");

            migrationBuilder.DropIndex(
                name: "IX_Nurses_ShiftIdId",
                table: "Nurses");

            migrationBuilder.DropIndex(
                name: "IX_Emplyees_ShiftIdId",
                table: "Emplyees");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_ShiftIdId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "ShiftId",
                table: "Nurses");

            migrationBuilder.DropColumn(
                name: "ShiftIdId",
                table: "Nurses");

            migrationBuilder.DropColumn(
                name: "ShiftId",
                table: "Emplyees");

            migrationBuilder.DropColumn(
                name: "ShiftIdId",
                table: "Emplyees");

            migrationBuilder.DropColumn(
                name: "ShiftId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "ShiftIdId",
                table: "Doctors");
        }
    }
}
