using Microsoft.EntityFrameworkCore.Migrations;

namespace MilkManagement.Domain.Migrations
{
    public partial class AddedCustomerTypeRelationToCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerTypeId",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerTypeId",
                table: "Customers",
                column: "CustomerTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CustomerTypes_CustomerTypeId",
                table: "Customers",
                column: "CustomerTypeId",
                principalTable: "CustomerTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CustomerTypes_CustomerTypeId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CustomerTypeId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerTypeId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Customers");
        }
    }
}
