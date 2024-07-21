﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeSharingSite.Migrations
{
    /// <inheritdoc />
    public partial class ChangedAuthorHandlingInRecipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "Recipes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "Recipes");
        }
    }
}
