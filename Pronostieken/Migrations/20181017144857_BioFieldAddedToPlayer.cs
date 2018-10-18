﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Pronostieken.Migrations
{
    public partial class BioFieldAddedToPlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "Players",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bio",
                table: "Players");
        }
    }
}
