using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Aaaa11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_paymentWays_paymentWayId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_paymentWayId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "paymentWayId",
                table: "Doctors");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Fk_PaymentId",
                table: "Doctors",
                column: "Fk_PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_paymentWays_Fk_PaymentId",
                table: "Doctors",
                column: "Fk_PaymentId",
                principalTable: "paymentWays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_paymentWays_Fk_PaymentId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_Fk_PaymentId",
                table: "Doctors");

            migrationBuilder.AddColumn<int>(
                name: "paymentWayId",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_paymentWayId",
                table: "Doctors",
                column: "paymentWayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_paymentWays_paymentWayId",
                table: "Doctors",
                column: "paymentWayId",
                principalTable: "paymentWays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
