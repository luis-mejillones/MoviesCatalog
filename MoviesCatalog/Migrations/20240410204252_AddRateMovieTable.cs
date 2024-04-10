using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesCatalog.Migrations
{
    public partial class AddRateMovieTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_RateMovies_RateMovieId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_RateMovies_RateMovieId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RateMovieId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Movies_RateMovieId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "RateMovieId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RateMovieId",
                table: "Movies");

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "RateMovies",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "RateMovies",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RateMovies_MovieId",
                table: "RateMovies",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_RateMovies_UserId",
                table: "RateMovies",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RateMovies_Movies_MovieId",
                table: "RateMovies",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RateMovies_Users_UserId",
                table: "RateMovies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RateMovies_Movies_MovieId",
                table: "RateMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_RateMovies_Users_UserId",
                table: "RateMovies");

            migrationBuilder.DropIndex(
                name: "IX_RateMovies_MovieId",
                table: "RateMovies");

            migrationBuilder.DropIndex(
                name: "IX_RateMovies_UserId",
                table: "RateMovies");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "RateMovies");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RateMovies");

            migrationBuilder.AddColumn<int>(
                name: "RateMovieId",
                table: "Users",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RateMovieId",
                table: "Movies",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RateMovieId",
                table: "Users",
                column: "RateMovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_RateMovieId",
                table: "Movies",
                column: "RateMovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_RateMovies_RateMovieId",
                table: "Movies",
                column: "RateMovieId",
                principalTable: "RateMovies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_RateMovies_RateMovieId",
                table: "Users",
                column: "RateMovieId",
                principalTable: "RateMovies",
                principalColumn: "Id");
        }
    }
}
