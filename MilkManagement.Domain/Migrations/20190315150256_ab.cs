using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MilkManagement.Domain.Migrations
{
    public partial class ab : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SupplierSupplied",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreatedById = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    LastUpdatedById = table.Column<int>(nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    SupplierId = table.Column<int>(nullable: false),
                    MorningPurchase = table.Column<string>(nullable: true),
                    AfternoonPurchase = table.Column<string>(nullable: true),
                    MorningAmount = table.Column<string>(nullable: true),
                    AfternoonAmount = table.Column<string>(nullable: true),
                    Rate = table.Column<int>(nullable: false),
                    Total = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierSupplied", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplierSupplied_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SupplierSupplied_SupplierId",
                table: "SupplierSupplied",
                column: "SupplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SupplierSupplied");
        }
    }
}
