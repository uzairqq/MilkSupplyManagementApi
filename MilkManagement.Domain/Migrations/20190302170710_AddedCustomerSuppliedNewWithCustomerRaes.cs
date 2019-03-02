using Microsoft.EntityFrameworkCore.Migrations;

namespace MilkManagement.Domain.Migrations
{
    public partial class AddedCustomerSuppliedNewWithCustomerRaes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rate",
                table: "CustomerSupplied");

            migrationBuilder.AddColumn<int>(
                name: "CustomerRatesId",
                table: "CustomerSupplied",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSupplied_CustomerRatesId",
                table: "CustomerSupplied",
                column: "CustomerRatesId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerSupplied_CustomerRates_CustomerRatesId",
                table: "CustomerSupplied",
                column: "CustomerRatesId",
                principalTable: "CustomerRates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerSupplied_CustomerRates_CustomerRatesId",
                table: "CustomerSupplied");

            migrationBuilder.DropIndex(
                name: "IX_CustomerSupplied_CustomerRatesId",
                table: "CustomerSupplied");

            migrationBuilder.DropColumn(
                name: "CustomerRatesId",
                table: "CustomerSupplied");

            migrationBuilder.AddColumn<float>(
                name: "Rate",
                table: "CustomerSupplied",
                nullable: true);
        }
    }
}
