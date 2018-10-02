using Microsoft.EntityFrameworkCore.Migrations;

namespace MilkManagement.Domain.Migrations
{
    public partial class AddedCustomerType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerType",
                table: "Customers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerType",
                table: "Customers");
        }
    }
}
