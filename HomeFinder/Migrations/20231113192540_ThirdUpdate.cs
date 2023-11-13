using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeFinder.Migrations
{
    public partial class ThirdUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImageContent",
                table: "HouseDetails",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "HouseDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageContent",
                table: "HouseDetails");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "HouseDetails");
        }
    }
}
