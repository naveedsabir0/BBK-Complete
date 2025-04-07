using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieDatabaseBlazorServerApp.Migrations
{
    /// <inheritdoc />
    public partial class viewlistofcyclists : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 1,
                column: "TotalCost",
                value: 43m);

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 2,
                column: "TotalCost",
                value: 23m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 1,
                column: "TotalCost",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 2,
                column: "TotalCost",
                value: 0m);
        }
    }
}
