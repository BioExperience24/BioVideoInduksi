using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePublishRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publishes_Players_Player_IdId",
                table: "Publishes");

            migrationBuilder.DropForeignKey(
                name: "FK_Publishes_Signages_Signage_IdId",
                table: "Publishes");

            migrationBuilder.RenameColumn(
                name: "Signage_IdId",
                table: "Publishes",
                newName: "SignageId");

            migrationBuilder.RenameColumn(
                name: "Player_IdId",
                table: "Publishes",
                newName: "PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Publishes_Signage_IdId",
                table: "Publishes",
                newName: "IX_Publishes_SignageId");

            migrationBuilder.RenameIndex(
                name: "IX_Publishes_Player_IdId",
                table: "Publishes",
                newName: "IX_Publishes_PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Publishes_Players_PlayerId",
                table: "Publishes",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Publishes_Signages_SignageId",
                table: "Publishes",
                column: "SignageId",
                principalTable: "Signages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publishes_Players_PlayerId",
                table: "Publishes");

            migrationBuilder.DropForeignKey(
                name: "FK_Publishes_Signages_SignageId",
                table: "Publishes");

            migrationBuilder.RenameColumn(
                name: "SignageId",
                table: "Publishes",
                newName: "Signage_IdId");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "Publishes",
                newName: "Player_IdId");

            migrationBuilder.RenameIndex(
                name: "IX_Publishes_SignageId",
                table: "Publishes",
                newName: "IX_Publishes_Signage_IdId");

            migrationBuilder.RenameIndex(
                name: "IX_Publishes_PlayerId",
                table: "Publishes",
                newName: "IX_Publishes_Player_IdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Publishes_Players_Player_IdId",
                table: "Publishes",
                column: "Player_IdId",
                principalTable: "Players",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Publishes_Signages_Signage_IdId",
                table: "Publishes",
                column: "Signage_IdId",
                principalTable: "Signages",
                principalColumn: "Id");
        }
    }
}
