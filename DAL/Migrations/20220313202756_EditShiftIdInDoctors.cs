using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class EditShiftIdInDoctors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Shifts_ShiftIdId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_ShiftIdId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "ShiftIdId",
                table: "Doctors");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_ShiftId",
                table: "Doctors",
                column: "ShiftId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Shifts_ShiftId",
                table: "Doctors",
                column: "ShiftId",
                principalTable: "Shifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Shifts_ShiftId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_ShiftId",
                table: "Doctors");

            migrationBuilder.AddColumn<int>(
                name: "ShiftIdId",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_ShiftIdId",
                table: "Doctors",
                column: "ShiftIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Shifts_ShiftIdId",
                table: "Doctors",
                column: "ShiftIdId",
                principalTable: "Shifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
