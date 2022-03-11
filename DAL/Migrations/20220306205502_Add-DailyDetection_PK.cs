using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddDailyDetection_PK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DailyDetection",
                table: "DailyDetection");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "DailyDetection",
                type: "int",
                nullable: false
               );

            migrationBuilder.AddPrimaryKey(
                name: "DailyDetection_PK",
                table: "DailyDetection",
                columns: new[] { "Id", "DateAndTime" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "DailyDetection_PK",
                table: "DailyDetection");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "DailyDetection",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DailyDetection",
                table: "DailyDetection",
                column: "Id");
        }
    }
}
