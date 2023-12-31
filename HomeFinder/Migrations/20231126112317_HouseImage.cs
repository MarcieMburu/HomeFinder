using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeFinder.Migrations
{
    public partial class HouseImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HouseImage",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseImage", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_HouseImage_HouseDetails_HouseId",
                        column: x => x.HouseId,
                        principalTable: "HouseDetails",
                        principalColumn: "HouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HouseImage_HouseId",
                table: "HouseImage",
                column: "HouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HouseImage");
        }
    }
}
