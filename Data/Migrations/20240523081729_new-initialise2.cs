using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieDatabaseBlazorServerApp.Migrations
{
    /// <inheritdoc />
    public partial class newinitialise2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieActor");

            migrationBuilder.DropTable(
                name: "Actor");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Studio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Forename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Studio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AverageBoxOfficeTotalForStudio = table.Column<long>(type: "bigint", nullable: false),
                    BoxOfficeTotalForStudio = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NumberOfMoviesReleased = table.Column<int>(type: "int", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreId = table.Column<int>(type: "int", nullable: true),
                    ImageFileId = table.Column<int>(type: "int", nullable: true),
                    StudioId = table.Column<int>(type: "int", nullable: true),
                    AgeRating = table.Column<int>(type: "int", nullable: true),
                    BoxOfficeTotal = table.Column<int>(type: "int", nullable: false),
                    ModifiedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false),
                    Synopsis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movie_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Movie_Studio_StudioId",
                        column: x => x.StudioId,
                        principalTable: "Studio",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Movie_UploadedFile_ImageFileId",
                        column: x => x.ImageFileId,
                        principalTable: "UploadedFile",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MovieActor",
                columns: table => new
                {
                    ActorId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieActor", x => new { x.ActorId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_MovieActor_Actor_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieActor_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actor",
                columns: new[] { "Id", "DateOfBirth", "Forename", "ImageFileName", "Surname" },
                values: new object[,]
                {
                    { 1, new DateTime(1950, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bill", "", "Murray" },
                    { 2, new DateTime(1952, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dan", "", "Aykroyd" },
                    { 3, new DateTime(1955, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bruce", "", "Willis" },
                    { 4, new DateTime(1947, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arnold", "", "Schwarzenegger" }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Comedy" },
                    { 2, "Sci/Fi" },
                    { 3, "Action" },
                    { 4, "Rom-Com" }
                });

            migrationBuilder.InsertData(
                table: "Studio",
                columns: new[] { "Id", "AverageBoxOfficeTotalForStudio", "BoxOfficeTotalForStudio", "Name", "NumberOfMoviesReleased", "URL" },
                values: new object[,]
                {
                    { 1, 0L, 0L, "Columbia Pictures", 0, "https://www.columbiapictures.com" },
                    { 2, 0L, 0L, "Orion Pictures", 0, "https://www.orionpictures.com" },
                    { 3, 0L, 0L, "20th Century Fox", 0, "https://www.20thcenturyfox.com" }
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "AgeRating", "BoxOfficeTotal", "GenreId", "ImageFileId", "ModifiedByUserId", "ReleaseYear", "StudioId", "Synopsis", "Title" },
                values: new object[,]
                {
                    { 1, null, 0, 1, null, null, 1984, null, "A group of scientists save New York from ghosts.", "Ghostbusters" },
                    { 2, null, 0, 2, null, null, 1987, null, "A cyborg police officer fights crime in a dystopian Detroit.", "RoboCop" },
                    { 3, null, 0, 3, null, null, 1988, null, "An NYPD officer saves hostages in a Los Angeles skyscraper.", "Die Hard" },
                    { 4, null, 0, 1, null, null, 1988, null, "The Ghostbusters return to battle a new wave of paranormal activity in New York.", "Ghostbusters 2" },
                    { 5, null, 0, 1, null, null, 2020, null, "An immigrant worker at a pickle factory is accidentally preserved for 100 years and wakes up in modern-day Brooklyn.", "An American Pickle" }
                });

            migrationBuilder.InsertData(
                table: "MovieActor",
                columns: new[] { "ActorId", "MovieId", "Salary" },
                values: new object[,]
                {
                    { 1, 1, 10000 },
                    { 1, 4, 40000 },
                    { 2, 1, 20000 },
                    { 2, 4, 50000 },
                    { 3, 3, 30000 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Genre_Name",
                table: "Genre",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movie_GenreId",
                table: "Movie",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_ImageFileId",
                table: "Movie",
                column: "ImageFileId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_StudioId",
                table: "Movie",
                column: "StudioId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieActor_MovieId",
                table: "MovieActor",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Studio_Name",
                table: "Studio",
                column: "Name",
                unique: true);
        }
    }
}
