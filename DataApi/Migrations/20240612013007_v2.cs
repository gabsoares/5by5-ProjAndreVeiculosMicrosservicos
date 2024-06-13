using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataApi.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CnhNumber",
                table: "Driver",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Bank",
                columns: table => new
                {
                    CNPJ = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoundationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.CNPJ);
                });

            migrationBuilder.CreateTable(
                name: "Financing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleId = table.Column<int>(type: "int", nullable: false),
                    FinancingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BankCNPJ = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Financing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Financing_Bank_BankCNPJ",
                        column: x => x.BankCNPJ,
                        principalTable: "Bank",
                        principalColumn: "CNPJ",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Financing_Sale_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Driver_CnhNumber",
                table: "Driver",
                column: "CnhNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Financing_BankCNPJ",
                table: "Financing",
                column: "BankCNPJ");

            migrationBuilder.CreateIndex(
                name: "IX_Financing_SaleId",
                table: "Financing",
                column: "SaleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Driver_Cnh_CnhNumber",
                table: "Driver",
                column: "CnhNumber",
                principalTable: "Cnh",
                principalColumn: "CnhNumber",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Driver_Cnh_CnhNumber",
                table: "Driver");

            migrationBuilder.DropTable(
                name: "Financing");

            migrationBuilder.DropTable(
                name: "Bank");

            migrationBuilder.DropIndex(
                name: "IX_Driver_CnhNumber",
                table: "Driver");

            migrationBuilder.DropColumn(
                name: "CnhNumber",
                table: "Driver");
        }
    }
}
