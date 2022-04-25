using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class CancelColmn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Cancel",
                table: "Treatment",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Cancel",
                table: "PatientRediology",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Cancel",
                table: "PatientMedicine",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Cancel",
                table: "PatientLab",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cancel",
                table: "Treatment");

            migrationBuilder.DropColumn(
                name: "Cancel",
                table: "PatientRediology");

            migrationBuilder.DropColumn(
                name: "Cancel",
                table: "PatientMedicine");

            migrationBuilder.DropColumn(
                name: "Cancel",
                table: "PatientLab");
        }
    }
}
