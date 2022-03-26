using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ShiftIdEditInEmplyeeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emplyees_Shifts_ShiftIdId",
                table: "Emplyees");

            migrationBuilder.DropIndex(
                name: "IX_Emplyees_ShiftIdId",
                table: "Emplyees");

            migrationBuilder.DropColumn(
                name: "ShiftIdId",
                table: "Emplyees");

            migrationBuilder.CreateIndex(
                name: "IX_Emplyees_ShiftId",
                table: "Emplyees",
                column: "ShiftId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emplyees_Shifts_ShiftId",
                table: "Emplyees",
                column: "ShiftId",
                principalTable: "Shifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emplyees_Shifts_ShiftId",
                table: "Emplyees");

            migrationBuilder.DropIndex(
                name: "IX_Emplyees_ShiftId",
                table: "Emplyees");

            migrationBuilder.AddColumn<int>(
                name: "ShiftIdId",
                table: "Emplyees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Emplyees_ShiftIdId",
                table: "Emplyees",
                column: "ShiftIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emplyees_Shifts_ShiftIdId",
                table: "Emplyees",
                column: "ShiftIdId",
                principalTable: "Shifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
