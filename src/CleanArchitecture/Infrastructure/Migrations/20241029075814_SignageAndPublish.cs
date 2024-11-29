using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SignageAndPublish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Signages_Templates_Template_IdId",
                table: "Signages");

            migrationBuilder.AlterColumn<int>(
                name: "Template_IdId",
                table: "Signages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "PlayerGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Serial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerGroup_IdId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_PlayerGroups_PlayerGroup_IdId",
                        column: x => x.PlayerGroup_IdId,
                        principalTable: "PlayerGroups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Publishes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PublishType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Player_IdId = table.Column<int>(type: "int", nullable: true),
                    Signage_IdId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Publishes_Players_Player_IdId",
                        column: x => x.Player_IdId,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Publishes_Signages_Signage_IdId",
                        column: x => x.Signage_IdId,
                        principalTable: "Signages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_PlayerGroup_IdId",
                table: "Players",
                column: "PlayerGroup_IdId");

            migrationBuilder.CreateIndex(
                name: "IX_Publishes_Player_IdId",
                table: "Publishes",
                column: "Player_IdId");

            migrationBuilder.CreateIndex(
                name: "IX_Publishes_Signage_IdId",
                table: "Publishes",
                column: "Signage_IdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Signages_Templates_Template_IdId",
                table: "Signages",
                column: "Template_IdId",
                principalTable: "Templates",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Signages_Templates_Template_IdId",
                table: "Signages");

            migrationBuilder.DropTable(
                name: "Publishes");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "PlayerGroups");

            migrationBuilder.AlterColumn<int>(
                name: "Template_IdId",
                table: "Signages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Signages_Templates_Template_IdId",
                table: "Signages",
                column: "Template_IdId",
                principalTable: "Templates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
