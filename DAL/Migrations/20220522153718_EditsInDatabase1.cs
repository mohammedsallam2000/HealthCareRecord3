using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class EditsInDatabase1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyDetection_Admin_AdminId",
                table: "DailyDetection");

            migrationBuilder.DropForeignKey(
                name: "FK_DailyDetection_Emplyees_EmplyeeId",
                table: "DailyDetection");

            migrationBuilder.DropForeignKey(
                name: "FK_DailyDetection_Nurses_NurseId",
                table: "DailyDetection");

            migrationBuilder.DropIndex(
                name: "IX_DailyDetection_AdminId",
                table: "DailyDetection");

            migrationBuilder.DropIndex(
                name: "IX_DailyDetection_EmplyeeId",
                table: "DailyDetection");

            migrationBuilder.DropIndex(
                name: "IX_DailyDetection_NurseId",
                table: "DailyDetection");

            migrationBuilder.DropColumn(
                name: "AnotherPhone",
                table: "Emplyees");

            migrationBuilder.DropColumn(
                name: "AnotherPhone",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Degree",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "DailyDetection");

            migrationBuilder.DropColumn(
                name: "EmplyeeId",
                table: "DailyDetection");

            migrationBuilder.DropColumn(
                name: "NurseId",
                table: "DailyDetection");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AnotherPhone",
                table: "Emplyees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AnotherPhone",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Degree",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "DailyDetection",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmplyeeId",
                table: "DailyDetection",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NurseId",
                table: "DailyDetection",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DailyDetection_AdminId",
                table: "DailyDetection",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyDetection_EmplyeeId",
                table: "DailyDetection",
                column: "EmplyeeId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyDetection_NurseId",
                table: "DailyDetection",
                column: "NurseId");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyDetection_Admin_AdminId",
                table: "DailyDetection",
                column: "AdminId",
                principalTable: "Admin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DailyDetection_Emplyees_EmplyeeId",
                table: "DailyDetection",
                column: "EmplyeeId",
                principalTable: "Emplyees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DailyDetection_Nurses_NurseId",
                table: "DailyDetection",
                column: "NurseId",
                principalTable: "Nurses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
