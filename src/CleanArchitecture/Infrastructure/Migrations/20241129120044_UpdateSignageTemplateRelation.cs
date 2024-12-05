using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSignageTemplateRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Signages_Templates_Template_IdId",
                table: "Signages");

            migrationBuilder.RenameColumn(
                name: "Template_IdId",
                table: "Signages",
                newName: "TemplateId");

            migrationBuilder.RenameIndex(
                name: "IX_Signages_Template_IdId",
                table: "Signages",
                newName: "IX_Signages_TemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Signages_Templates_TemplateId",
                table: "Signages",
                column: "TemplateId",
                principalTable: "Templates",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Signages_Templates_TemplateId",
                table: "Signages");

            migrationBuilder.RenameColumn(
                name: "TemplateId",
                table: "Signages",
                newName: "Template_IdId");

            migrationBuilder.RenameIndex(
                name: "IX_Signages_TemplateId",
                table: "Signages",
                newName: "IX_Signages_Template_IdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Signages_Templates_Template_IdId",
                table: "Signages",
                column: "Template_IdId",
                principalTable: "Templates",
                principalColumn: "Id");
        }
    }
}
