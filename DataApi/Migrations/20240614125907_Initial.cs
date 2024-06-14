using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false),
                    UF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adress", x => x.Id);
                });

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
                name: "Car",
                columns: table => new
                {
                    CarPlate = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CarName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelYear = table.Column<int>(type: "int", nullable: false),
                    FabricationYear = table.Column<int>(type: "int", nullable: false),
                    CarColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSold = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.CarPlate);
                });

            migrationBuilder.CreateTable(
                name: "CnhCategory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CnhCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditCard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CardHolderName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCard", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PixType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PixType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CPF = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Income = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PDFDocument = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdressId = table.Column<int>(type: "int", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CPF);
                    table.ForeignKey(
                        name: "FK_Customer_Adress_AdressId",
                        column: x => x.AdressId,
                        principalTable: "Adress",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateTable(
                name: "Cnh",
                columns: table => new
                {
                    CnhNumber = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DadName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cnh", x => x.CnhNumber);
                    table.ForeignKey(
                        name: "FK_Cnh_CnhCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CnhCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarJob",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarPlate = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarJob", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarJob_Car_CarPlate",
                        column: x => x.CarPlate,
                        principalTable: "Car",
                        principalColumn: "CarPlate");
                    table.ForeignKey(
                        name: "FK_CarJob_Job_JobId",
                        column: x => x.JobId,
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pix",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PixTypeId = table.Column<int>(type: "int", nullable: true),
                    PixKey = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pix", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pix_PixType_PixTypeId",
                        column: x => x.PixTypeId,
                        principalTable: "PixType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    CPF = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    ComissionValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comission = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdressId = table.Column<int>(type: "int", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.CPF);
                    table.ForeignKey(
                        name: "FK_Employee_Adress_AdressId",
                        column: x => x.AdressId,
                        principalTable: "Adress",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employee_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Dependent",
                columns: table => new
                {
                    CPF = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerCPF = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdressId = table.Column<int>(type: "int", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependent", x => x.CPF);
                    table.ForeignKey(
                        name: "FK_Dependent_Adress_AdressId",
                        column: x => x.AdressId,
                        principalTable: "Adress",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Dependent_Customer_CustomerCPF",
                        column: x => x.CustomerCPF,
                        principalTable: "Customer",
                        principalColumn: "CPF");
                });

            migrationBuilder.CreateTable(
                name: "FinancialPending",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PendingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BillingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CustomerCPF = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialPending", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinancialPending_Customer_CustomerCPF",
                        column: x => x.CustomerCPF,
                        principalTable: "Customer",
                        principalColumn: "CPF");
                });

            migrationBuilder.CreateTable(
                name: "Driver",
                columns: table => new
                {
                    CPF = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CnhNumber = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdressId = table.Column<int>(type: "int", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Driver", x => x.CPF);
                    table.ForeignKey(
                        name: "FK_Driver_Adress_AdressId",
                        column: x => x.AdressId,
                        principalTable: "Adress",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Driver_Cnh_CnhNumber",
                        column: x => x.CnhNumber,
                        principalTable: "Cnh",
                        principalColumn: "CnhNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditCardId = table.Column<int>(type: "int", nullable: true),
                    TicketId = table.Column<int>(type: "int", nullable: true),
                    PixId = table.Column<int>(type: "int", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_CreditCard_CreditCardId",
                        column: x => x.CreditCardId,
                        principalTable: "CreditCard",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Payment_Pix_PixId",
                        column: x => x.PixId,
                        principalTable: "Pix",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Payment_Ticket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Ticket",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Insurance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerCPF = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Franchise = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CarPlate = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DriverCPF = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Insurance_Car_CarPlate",
                        column: x => x.CarPlate,
                        principalTable: "Car",
                        principalColumn: "CarPlate");
                    table.ForeignKey(
                        name: "FK_Insurance_Customer_CustomerCPF",
                        column: x => x.CustomerCPF,
                        principalTable: "Customer",
                        principalColumn: "CPF");
                    table.ForeignKey(
                        name: "FK_Insurance_Driver_DriverCPF",
                        column: x => x.DriverCPF,
                        principalTable: "Driver",
                        principalColumn: "CPF");
                });

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
                name: "IX_CarJob_CarPlate",
                table: "CarJob",
                column: "CarPlate");

            migrationBuilder.CreateIndex(
                name: "IX_CarJob_JobId",
                table: "CarJob",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Cnh_CategoryId",
                table: "Cnh",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_AdressId",
                table: "Customer",
                column: "AdressId");

            migrationBuilder.CreateIndex(
                name: "IX_Dependent_AdressId",
                table: "Dependent",
                column: "AdressId");

            migrationBuilder.CreateIndex(
                name: "IX_Dependent_CustomerCPF",
                table: "Dependent",
                column: "CustomerCPF");

            migrationBuilder.CreateIndex(
                name: "IX_Driver_AdressId",
                table: "Driver",
                column: "AdressId");

            migrationBuilder.CreateIndex(
                name: "IX_Driver_CnhNumber",
                table: "Driver",
                column: "CnhNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_AdressId",
                table: "Employee",
                column: "AdressId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_RoleId",
                table: "Employee",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialPending_CustomerCPF",
                table: "FinancialPending",
                column: "CustomerCPF");

            migrationBuilder.CreateIndex(
                name: "IX_Financing_BankCNPJ",
                table: "Financing",
                column: "BankCNPJ");

            migrationBuilder.CreateIndex(
                name: "IX_Financing_SaleId",
                table: "Financing",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Insurance_CarPlate",
                table: "Insurance",
                column: "CarPlate");

            migrationBuilder.CreateIndex(
                name: "IX_Insurance_CustomerCPF",
                table: "Insurance",
                column: "CustomerCPF");

            migrationBuilder.CreateIndex(
                name: "IX_Insurance_DriverCPF",
                table: "Insurance",
                column: "DriverCPF");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_CreditCardId",
                table: "Payment",
                column: "CreditCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_PixId",
                table: "Payment",
                column: "PixId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_TicketId",
                table: "Payment",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Pix_PixTypeId",
                table: "Pix",
                column: "PixTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_CarPlate",
                table: "Purchase",
                column: "CarPlate");

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
                name: "CarJob");

            migrationBuilder.DropTable(
                name: "Dependent");

            migrationBuilder.DropTable(
                name: "FinancialPending");

            migrationBuilder.DropTable(
                name: "Financing");

            migrationBuilder.DropTable(
                name: "Insurance");

            migrationBuilder.DropTable(
                name: "Purchase");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "Bank");

            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropTable(
                name: "Driver");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Cnh");

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
                name: "CnhCategory");

            migrationBuilder.DropTable(
                name: "PixType");
        }
    }
}
