using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIAndreVeiculosMicrosservicos.Sale.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarPlate = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SaleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SaleValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClientCPF = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EmployeeCPF = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PaymentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sale_Car_CarPlate",
                        column: x => x.CarPlate,
                        principalTable: "Car",
                        principalColumn: "CarPlate");
                    table.ForeignKey(
                        name: "FK_Sale_Customer_ClientCPF",
                        column: x => x.ClientCPF,
                        principalTable: "Customer",
                        principalColumn: "CPF");
                    table.ForeignKey(
                        name: "FK_Sale_Employee_EmployeeCPF",
                        column: x => x.EmployeeCPF,
                        principalTable: "Employee",
                        principalColumn: "CPF");
                    table.ForeignKey(
                        name: "FK_Sale_Payment_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payment",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sale_CarPlate",
                table: "Sale",
                column: "CarPlate");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_ClientCPF",
                table: "Sale",
                column: "ClientCPF");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_EmployeeCPF",
                table: "Sale",
                column: "EmployeeCPF");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_PaymentId",
                table: "Sale",
                column: "PaymentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Adress");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "CreditCard");

            migrationBuilder.DropTable(
                name: "Pix");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "PixType");
        }
    }
}
