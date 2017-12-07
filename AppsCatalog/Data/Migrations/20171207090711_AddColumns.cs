using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AppsCatalog.Data.Migrations
{
    public partial class AddColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverForModels",
                table: "Applications");

            migrationBuilder.AddColumn<byte[]>(
                name: "Cover",
                table: "Applications",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cover",
                table: "Applications");

            migrationBuilder.AddColumn<byte[]>(
                name: "CoverForModels",
                table: "Applications",
                nullable: true);
        }
    }
}
