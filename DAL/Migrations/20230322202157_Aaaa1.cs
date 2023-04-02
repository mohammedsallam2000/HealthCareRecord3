using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Aaaa1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Fk_PaymentId",
                table: "Nurses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Salary",
                table: "Nurses",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ShiftPrise",
                table: "Nurses",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "TypeWorkId",
                table: "Nurses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "paymentWayId",
                table: "Nurses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Fk_PaymentId",
                table: "Emplyees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Salary",
                table: "Emplyees",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ShiftPrise",
                table: "Emplyees",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "TypeWorkId",
                table: "Emplyees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "paymentWayId",
                table: "Emplyees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Fk_PaymentId",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Salary",
                table: "Doctors",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ShiftPrise",
                table: "Doctors",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "TypeWorkId",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "paymentWayId",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "comeandLeveEmployyes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    come = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Leave = table.Column<DateTime>(type: "datetime2", nullable: false),
                    comeLate = table.Column<double>(type: "float", nullable: false),
                    LeaveEaley = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comeandLeveEmployyes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_comeandLeveEmployyes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "paymentWays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paymentWays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "typeWorks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_typeWorks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "workshifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workshifts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "userWorkShifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShiftWorkId = table.Column<int>(type: "int", nullable: false),
                    WorkshiftId = table.Column<int>(type: "int", nullable: true),
                    PaymentYes = table.Column<bool>(type: "bit", nullable: false),
                    Fk_comeandLeaveEmployee = table.Column<int>(type: "int", nullable: false),
                    comeandLeveEmployyeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userWorkShifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userWorkShifts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_userWorkShifts_comeandLeveEmployyes_comeandLeveEmployyeID",
                        column: x => x.comeandLeveEmployyeID,
                        principalTable: "comeandLeveEmployyes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_userWorkShifts_workshifts_WorkshiftId",
                        column: x => x.WorkshiftId,
                        principalTable: "workshifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nurses_paymentWayId",
                table: "Nurses",
                column: "paymentWayId");

            migrationBuilder.CreateIndex(
                name: "IX_Nurses_TypeWorkId",
                table: "Nurses",
                column: "TypeWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Emplyees_paymentWayId",
                table: "Emplyees",
                column: "paymentWayId");

            migrationBuilder.CreateIndex(
                name: "IX_Emplyees_TypeWorkId",
                table: "Emplyees",
                column: "TypeWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_paymentWayId",
                table: "Doctors",
                column: "paymentWayId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_TypeWorkId",
                table: "Doctors",
                column: "TypeWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_comeandLeveEmployyes_UserId",
                table: "comeandLeveEmployyes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_userWorkShifts_comeandLeveEmployyeID",
                table: "userWorkShifts",
                column: "comeandLeveEmployyeID");

            migrationBuilder.CreateIndex(
                name: "IX_userWorkShifts_UserId",
                table: "userWorkShifts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_userWorkShifts_WorkshiftId",
                table: "userWorkShifts",
                column: "WorkshiftId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_paymentWays_paymentWayId",
                table: "Doctors",
                column: "paymentWayId",
                principalTable: "paymentWays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_typeWorks_TypeWorkId",
                table: "Doctors",
                column: "TypeWorkId",
                principalTable: "typeWorks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Emplyees_paymentWays_paymentWayId",
                table: "Emplyees",
                column: "paymentWayId",
                principalTable: "paymentWays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Emplyees_typeWorks_TypeWorkId",
                table: "Emplyees",
                column: "TypeWorkId",
                principalTable: "typeWorks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Nurses_paymentWays_paymentWayId",
                table: "Nurses",
                column: "paymentWayId",
                principalTable: "paymentWays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Nurses_typeWorks_TypeWorkId",
                table: "Nurses",
                column: "TypeWorkId",
                principalTable: "typeWorks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_paymentWays_paymentWayId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_typeWorks_TypeWorkId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Emplyees_paymentWays_paymentWayId",
                table: "Emplyees");

            migrationBuilder.DropForeignKey(
                name: "FK_Emplyees_typeWorks_TypeWorkId",
                table: "Emplyees");

            migrationBuilder.DropForeignKey(
                name: "FK_Nurses_paymentWays_paymentWayId",
                table: "Nurses");

            migrationBuilder.DropForeignKey(
                name: "FK_Nurses_typeWorks_TypeWorkId",
                table: "Nurses");

            migrationBuilder.DropTable(
                name: "paymentWays");

            migrationBuilder.DropTable(
                name: "typeWorks");

            migrationBuilder.DropTable(
                name: "userWorkShifts");

            migrationBuilder.DropTable(
                name: "comeandLeveEmployyes");

            migrationBuilder.DropTable(
                name: "workshifts");

            migrationBuilder.DropIndex(
                name: "IX_Nurses_paymentWayId",
                table: "Nurses");

            migrationBuilder.DropIndex(
                name: "IX_Nurses_TypeWorkId",
                table: "Nurses");

            migrationBuilder.DropIndex(
                name: "IX_Emplyees_paymentWayId",
                table: "Emplyees");

            migrationBuilder.DropIndex(
                name: "IX_Emplyees_TypeWorkId",
                table: "Emplyees");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_paymentWayId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_TypeWorkId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Fk_PaymentId",
                table: "Nurses");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Nurses");

            migrationBuilder.DropColumn(
                name: "ShiftPrise",
                table: "Nurses");

            migrationBuilder.DropColumn(
                name: "TypeWorkId",
                table: "Nurses");

            migrationBuilder.DropColumn(
                name: "paymentWayId",
                table: "Nurses");

            migrationBuilder.DropColumn(
                name: "Fk_PaymentId",
                table: "Emplyees");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Emplyees");

            migrationBuilder.DropColumn(
                name: "ShiftPrise",
                table: "Emplyees");

            migrationBuilder.DropColumn(
                name: "TypeWorkId",
                table: "Emplyees");

            migrationBuilder.DropColumn(
                name: "paymentWayId",
                table: "Emplyees");

            migrationBuilder.DropColumn(
                name: "Fk_PaymentId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "ShiftPrise",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "TypeWorkId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "paymentWayId",
                table: "Doctors");
        }
    }
}
