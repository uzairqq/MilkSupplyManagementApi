using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MilkManagement.Domain.Migrations
{
    public partial class AddedMarketSell : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MarketSell",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedById = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdatedById = table.Column<int>(nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    MarketSupplierId = table.Column<int>(nullable: false),
                    MorningSell = table.Column<string>(nullable: true),
                    MorningAmount = table.Column<string>(nullable: true),
                    MorningRate = table.Column<string>(nullable: true),
                    AfternoonSell = table.Column<string>(nullable: true),
                    AfternoonAmount = table.Column<string>(nullable: true),
                    AfternoonRate = table.Column<string>(nullable: true),
                    Total = table.Column<string>(nullable: true),
                    ComissionRate = table.Column<int>(nullable: false),
                    TotalComission = table.Column<int>(nullable: true),
                    TotalMilk = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketSell", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketSell_MarketSupplier_MarketSupplierId",
                        column: x => x.MarketSupplierId,
                        principalTable: "MarketSupplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MarketSell_MarketSupplierId",
                table: "MarketSell",
                column: "MarketSupplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarketSell");
        }
    }
}
