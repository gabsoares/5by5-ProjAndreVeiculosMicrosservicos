using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataApi.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerCPF",
                table: "Dependent",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dependent_CustomerCPF",
                table: "Dependent",
                column: "CustomerCPF");

            migrationBuilder.AddForeignKey(
                name: "FK_Dependent_Customer_CustomerCPF",
                table: "Dependent",
                column: "CustomerCPF",
                principalTable: "Customer",
                principalColumn: "CPF");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dependent_Customer_CustomerCPF",
                table: "Dependent");

            migrationBuilder.DropIndex(
                name: "IX_Dependent_CustomerCPF",
                table: "Dependent");

            migrationBuilder.DropColumn(
                name: "CustomerCPF",
                table: "Dependent");
        }
    }
}
