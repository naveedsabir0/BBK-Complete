using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieDatabaseBlazorServerApp.Migrations
{
    /// <inheritdoc />
    public partial class addedavveragebox : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AverageBoxOfficeTotalForStudio",
                table: "Studio",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfMoviesReleased",
                table: "Studio",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AverageBoxOfficeTotalForStudio",
                table: "Studio");

            migrationBuilder.DropColumn(
                name: "NumberOfMoviesReleased",
                table: "Studio");
        }
    }
}
