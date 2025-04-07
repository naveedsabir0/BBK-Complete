using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieDatabaseBlazorServerApp.Migrations
{
    /// <inheritdoc />
    public partial class updatedboxoffice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BoxOfficeTotalForStudio",
                table: "Studio",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoxOfficeTotalForStudio",
                table: "Studio");
        }
    }
}
