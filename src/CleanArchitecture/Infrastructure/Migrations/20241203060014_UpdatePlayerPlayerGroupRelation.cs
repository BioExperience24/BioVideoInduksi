using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePlayerPlayerGroupRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_PlayerGroups_PlayerGroup_IdId",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "PlayerGroup_IdId",
                table: "Players",
                newName: "PlayerGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Players_PlayerGroup_IdId",
                table: "Players",
                newName: "IX_Players_PlayerGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_PlayerGroups_PlayerGroupId",
                table: "Players",
                column: "PlayerGroupId",
                principalTable: "PlayerGroups",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_PlayerGroups_PlayerGroupId",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "PlayerGroupId",
                table: "Players",
                newName: "PlayerGroup_IdId");

            migrationBuilder.RenameIndex(
                name: "IX_Players_PlayerGroupId",
                table: "Players",
                newName: "IX_Players_PlayerGroup_IdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_PlayerGroups_PlayerGroup_IdId",
                table: "Players",
                column: "PlayerGroup_IdId",
                principalTable: "PlayerGroups",
                principalColumn: "Id");
        }
    }
}
