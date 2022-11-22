using Microsoft.EntityFrameworkCore.Migrations;

namespace BlueEconomy.Migrations
{
    public partial class boatAndMwaniRelations1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "boatStock",
                columns: table => new
                {
                    BoatStockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sneb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sneg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lifeJacket = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    boatLength = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    boatPrice = table.Column<float>(type: "real", nullable: false),
                    noAnchor = table.Column<int>(type: "int", nullable: false),
                    noOfRope = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_boatStock", x => x.BoatStockId);
                });

            migrationBuilder.CreateTable(
                name: "fishBoats",
                columns: table => new
                {
                    FishBoatsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    noOfTraps = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoatStockId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fishBoats", x => x.FishBoatsId);
                    table.ForeignKey(
                        name: "FK_fishBoats_boatStock_BoatStockId",
                        column: x => x.BoatStockId,
                        principalTable: "boatStock",
                        principalColumn: "BoatStockId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_fishBoats_BoatStockId",
                table: "fishBoats",
                column: "BoatStockId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fishBoats");

            migrationBuilder.DropTable(
                name: "boatStock");
        }
    }
}
