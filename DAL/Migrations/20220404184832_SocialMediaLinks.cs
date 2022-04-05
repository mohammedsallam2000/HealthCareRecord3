using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class SocialMediaLinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Twitter",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Whatsapp",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "Nurses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Twitter",
                table: "Nurses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Whatsapp",
                table: "Nurses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "Emplyees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Twitter",
                table: "Emplyees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Whatsapp",
                table: "Emplyees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Twitter",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Whatsapp",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Twitter",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Whatsapp",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Twitter",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Whatsapp",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "Nurses");

            migrationBuilder.DropColumn(
                name: "Twitter",
                table: "Nurses");

            migrationBuilder.DropColumn(
                name: "Whatsapp",
                table: "Nurses");

            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "Emplyees");

            migrationBuilder.DropColumn(
                name: "Twitter",
                table: "Emplyees");

            migrationBuilder.DropColumn(
                name: "Whatsapp",
                table: "Emplyees");

            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Twitter",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Whatsapp",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "Twitter",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "Whatsapp",
                table: "Admin");
        }
    }
}
