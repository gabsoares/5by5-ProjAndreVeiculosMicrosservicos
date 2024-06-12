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

            migrationBuilder.CreateIndex(
                name: "IX_Driver_CnhNumber",
                table: "Driver",
                column: "CnhNumber");

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

            migrationBuilder.DropIndex(
                name: "IX_Driver_CnhNumber",
                table: "Driver");

            migrationBuilder.DropColumn(
                name: "CnhNumber",
                table: "Driver");
        }
    }
}
