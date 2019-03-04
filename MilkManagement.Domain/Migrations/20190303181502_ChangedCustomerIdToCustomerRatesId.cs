using Microsoft.EntityFrameworkCore.Migrations;

namespace MilkManagement.Domain.Migrations
{
    public partial class ChangedCustomerIdToCustomerRatesId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerSupplied_CustomerRates_CustomerRatesId",
                table: "CustomerSupplied");

            migrationBuilder.DropColumn(
                name: "CustomerRatesId",
                table: "CustomerSupplied");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerRatesId",
                table: "CustomerSupplied",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerSupplied_CustomerRates_CustomerRatesId",
                table: "CustomerSupplied",
                column: "CustomerRatesId",
                principalTable: "CustomerRates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerSupplied_CustomerRates_CustomerRatesId",
                table: "CustomerSupplied");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerRatesId",
                table: "CustomerSupplied",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CustomerRatesId",
                table: "CustomerSupplied",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerSupplied_CustomerRates_CustomerRatesId",
                table: "CustomerSupplied",
                column: "CustomerRatesId",
                principalTable: "CustomerRates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
