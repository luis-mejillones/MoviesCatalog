using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesCatalog.Migrations
{
    public partial class AddMovieTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RateMovieId",
                table: "Users",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RateMovies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Rate = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RateMovies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ReleaseYear = table.Column<int>(type: "INTEGER", nullable: false),
                    Synopsis = table.Column<string>(type: "TEXT", nullable: true),
                    UrlPoster = table.Column<string>(type: "TEXT", nullable: true),
                    MovieCategory = table.Column<int>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true),
                    RateMovieId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_RateMovies_RateMovieId",
                        column: x => x.RateMovieId,
                        principalTable: "RateMovies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Movies_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RateMovieId",
                table: "Users",
                column: "RateMovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_RateMovieId",
                table: "Movies",
                column: "RateMovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_UserId",
                table: "Movies",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_RateMovies_RateMovieId",
                table: "Users",
                column: "RateMovieId",
                principalTable: "RateMovies",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_RateMovies_RateMovieId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "RateMovies");

            migrationBuilder.DropIndex(
                name: "IX_Users_RateMovieId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RateMovieId",
                table: "Users");
        }
    }
}
