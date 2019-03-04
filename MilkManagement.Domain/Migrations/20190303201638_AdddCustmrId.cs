using Microsoft.EntityFrameworkCore.Migrations;

namespace MilkManagement.Domain.Migrations
{
    public partial class AdddCustmrId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "CustomerSupplied",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSupplied_CustomerId",
                table: "CustomerSupplied",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerSupplied_Customers_CustomerId",
                table: "CustomerSupplied",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerSupplied_Customers_CustomerId",
                table: "CustomerSupplied");

            migrationBuilder.DropIndex(
                name: "IX_CustomerSupplied_CustomerId",
                table: "CustomerSupplied");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "CustomerSupplied");
        }
    }
}
