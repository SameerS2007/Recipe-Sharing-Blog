﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeSharingSite.Migrations
{
    /// <inheritdoc />
    public partial class updatemigrationActualInitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Authors",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Authors");
        }
    }
}
