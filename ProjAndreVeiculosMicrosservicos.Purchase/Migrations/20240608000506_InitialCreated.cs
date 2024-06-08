using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIAndreVeiculosMicrosservicos.Purchase.Migrations
{
    public partial class InitialCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarPlate = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchase_Car_CarPlate",
                        column: x => x.CarPlate,
                        principalTable: "Car",
                        principalColumn: "CarPlate");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_CarPlate",
                table: "Purchase",
                column: "CarPlate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchase");
        }
    }
}
