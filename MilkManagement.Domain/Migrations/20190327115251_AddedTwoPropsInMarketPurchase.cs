using Microsoft.EntityFrameworkCore.Migrations;

namespace MilkManagement.Domain.Migrations
{
    public partial class AddedTwoPropsInMarketPurchase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Total",
                table: "MarketPurchase",
                newName: "TotalAmount");

            migrationBuilder.AddColumn<string>(
                name: "TotalMilk",
                table: "MarketPurchase",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalMilk",
                table: "MarketPurchase");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "MarketPurchase",
                newName: "Total");
        }
    }
}
