using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddFKDeptIdInDailayDetection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "DailyDetection",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DailyDetection_DepartmentId",
                table: "DailyDetection",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyDetection_Departments_DepartmentId",
                table: "DailyDetection",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyDetection_Departments_DepartmentId",
                table: "DailyDetection");

            migrationBuilder.DropIndex(
                name: "IX_DailyDetection_DepartmentId",
                table: "DailyDetection");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "DailyDetection");
        }
    }
}
