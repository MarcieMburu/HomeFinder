using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeFinder.Migrations
{
    public partial class ThirdCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "HouseImage",
                table: "HouseDetails",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HouseImage",
                table: "HouseDetails");
        }
    }
}
