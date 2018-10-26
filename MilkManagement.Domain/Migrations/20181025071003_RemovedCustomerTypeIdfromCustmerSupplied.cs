using Microsoft.EntityFrameworkCore.Migrations;

namespace MilkManagement.Domain.Migrations
{
    public partial class RemovedCustomerTypeIdfromCustmerSupplied : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerSupplied_CustomerTypes_CustomerTypeId",
                table: "CustomerSupplied");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerTypeId",
                table: "CustomerSupplied",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerSupplied_CustomerTypes_CustomerTypeId",
                table: "CustomerSupplied",
                column: "CustomerTypeId",
                principalTable: "CustomerTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerSupplied_CustomerTypes_CustomerTypeId",
                table: "CustomerSupplied");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerTypeId",
                table: "CustomerSupplied",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerSupplied_CustomerTypes_CustomerTypeId",
                table: "CustomerSupplied",
                column: "CustomerTypeId",
                principalTable: "CustomerTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
