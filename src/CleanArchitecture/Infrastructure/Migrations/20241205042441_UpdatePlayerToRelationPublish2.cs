﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePlayerToRelationPublish2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Publishes_PlayerId",
                table: "Publishes");

            migrationBuilder.CreateIndex(
                name: "IX_Publishes_PlayerId",
                table: "Publishes",
                column: "PlayerId",
                unique: true,
                filter: "[PlayerId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Publishes_PlayerId",
                table: "Publishes");

            migrationBuilder.CreateIndex(
                name: "IX_Publishes_PlayerId",
                table: "Publishes",
                column: "PlayerId");
        }
    }
}