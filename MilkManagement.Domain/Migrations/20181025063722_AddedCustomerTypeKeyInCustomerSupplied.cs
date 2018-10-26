using Microsoft.EntityFrameworkCore.Migrations;

namespace MilkManagement.Domain.Migrations
{
    public partial class AddedCustomerTypeKeyInCustomerSupplied : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerTypeId",
                table: "CustomerSupplied",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSupplied_CustomerTypeId",
                table: "CustomerSupplied",
                column: "CustomerTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerSupplied_CustomerTypes_CustomerTypeId",
                table: "CustomerSupplied",
                column: "CustomerTypeId",
                principalTable: "CustomerTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerSupplied_CustomerTypes_CustomerTypeId",
                table: "CustomerSupplied");

            migrationBuilder.DropIndex(
                name: "IX_CustomerSupplied_CustomerTypeId",
                table: "CustomerSupplied");

            migrationBuilder.DropColumn(
                name: "CustomerTypeId",
                table: "CustomerSupplied");
        }
    }
}
