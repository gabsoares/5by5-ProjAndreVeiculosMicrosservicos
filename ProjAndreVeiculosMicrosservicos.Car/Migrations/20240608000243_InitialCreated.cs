using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIAndreVeiculosMicrosservicos.Car.Migrations
{
    public partial class InitialCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car");
        }
    }
}
