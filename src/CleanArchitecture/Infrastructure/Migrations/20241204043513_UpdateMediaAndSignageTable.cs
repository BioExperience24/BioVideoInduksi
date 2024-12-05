using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMediaAndSignageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Signages");

            migrationBuilder.AddColumn<string>(
                name: "Filename",
                table: "Media",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Filename",
                table: "Media");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Signages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
