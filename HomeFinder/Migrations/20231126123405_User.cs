using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeFinder.Migrations
{
    public partial class User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HouseImage_HouseDetails_HouseId",
                table: "HouseImage");

            migrationBuilder.DropTable(
                name: "UserDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HouseImage",
                table: "HouseImage");

            migrationBuilder.RenameTable(
                name: "HouseImage",
                newName: "HouseImages");

            migrationBuilder.RenameIndex(
                name: "IX_HouseImage_HouseId",
                table: "HouseImages",
                newName: "IX_HouseImages_HouseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HouseImages",
                table: "HouseImages",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_HouseImages_HouseDetails_HouseId",
                table: "HouseImages",
                column: "HouseId",
                principalTable: "HouseDetails",
                principalColumn: "HouseId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HouseImages_HouseDetails_HouseId",
                table: "HouseImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HouseImages",
                table: "HouseImages");

            migrationBuilder.RenameTable(
                name: "HouseImages",
                newName: "HouseImage");

            migrationBuilder.RenameIndex(
                name: "IX_HouseImages_HouseId",
                table: "HouseImage",
                newName: "IX_HouseImage_HouseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HouseImage",
                table: "HouseImage",
                column: "ImageId");

            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.UserId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_HouseImage_HouseDetails_HouseId",
                table: "HouseImage",
                column: "HouseId",
                principalTable: "HouseDetails",
                principalColumn: "HouseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
