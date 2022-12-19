using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypesAnime",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesAnime", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Animes",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Season = table.Column<int>(type: "INTEGER", nullable: false),
                    DateStart = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TypeGuid = table.Column<Guid>(type: "TEXT", nullable: true),
                    Rating = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animes", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Animes_TypesAnime_TypeGuid",
                        column: x => x.TypeGuid,
                        principalTable: "TypesAnime",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    AnimeGuid = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Tags_Animes_AnimeGuid",
                        column: x => x.AnimeGuid,
                        principalTable: "Animes",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animes_TypeGuid",
                table: "Animes",
                column: "TypeGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_AnimeGuid",
                table: "Tags",
                column: "AnimeGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Animes");

            migrationBuilder.DropTable(
                name: "TypesAnime");
        }
    }
}
