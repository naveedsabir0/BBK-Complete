using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieDatabaseBlazorServerApp.Migrations
{
    /// <inheritdoc />
    public partial class backupfinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RepairRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VolunteerId = table.Column<int>(type: "int", nullable: false),
                    RepairDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RepairTime = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepairRecords_Volunteers_VolunteerId",
                        column: x => x.VolunteerId,
                        principalTable: "Volunteers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "Bike Maintenance");

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "Road Safety");

            migrationBuilder.InsertData(
                table: "Cyclists",
                columns: new[] { "Id", "Address", "DateOfBirth", "Email", "Forename", "ImageFileName", "Phone", "Surname" },
                values: new object[,]
                {
                    { 3, "789 Birch St", new DateTime(1992, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "tom.harris@example.com", "Tom", "", "1112223333", "Harris" },
                    { 4, "321 Maple St", new DateTime(1988, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "lucy.brown@example.com", "Lucy", "", "2223334444", "Brown" },
                    { 5, "654 Cedar St", new DateTime(1979, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "mark.wilson@example.com", "Mark", "", "3334445555", "Wilson" },
                    { 6, "987 Ash St", new DateTime(1995, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "emma.green@example.com", "Emma", "", "4445556666", "Green" }
                });

            migrationBuilder.InsertData(
                table: "Volunteers",
                columns: new[] { "Id", "Address", "DateOfBirth", "Email", "Forename", "ImageFileName", "Phone", "Surname" },
                values: new object[,]
                {
                    { 3, "654 Willow St", new DateTime(1990, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "clara.davis@example.com", "Clara", "", "5556667777", "Davis" },
                    { 4, "321 Chestnut St", new DateTime(1983, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "david.martin@example.com", "David", "", "6667778888", "Martin" },
                    { 5, "987 Walnut St", new DateTime(1978, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ella.clark@example.com", "Ella", "", "7778889999", "Clark" },
                    { 6, "123 Poplar St", new DateTime(1992, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "frank.garcia@example.com", "Frank", "", "8889990000", "Garcia" }
                });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "CyclistId", "Make", "Model", "RepairId" },
                values: new object[,]
                {
                    { 3, 3, "Specialized", "Allez", 0 },
                    { 4, 4, "Cannondale", "Synapse", 0 },
                    { 5, 5, "Bianchi", "Impulso", 0 },
                    { 6, 6, "Scott", "Speedster", 0 }
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "AttendanceCount", "CyclistId", "Date", "Title", "VolunteerId" },
                values: new object[,]
                {
                    { 3, 0, 3, new DateOnly(2024, 5, 3), "Mountain Biking Basics", 3 },
                    { 4, 0, 4, new DateOnly(2024, 5, 4), "Advanced Cycling Techniques", 4 },
                    { 5, 0, 5, new DateOnly(2024, 5, 5), "Cycling Endurance Training", 5 },
                    { 6, 0, 6, new DateOnly(2024, 5, 6), "Urban Cycling Tips", 6 }
                });

            migrationBuilder.InsertData(
                table: "Repairs",
                columns: new[] { "Id", "BikeID", "Date", "Title", "TotalCost" },
                values: new object[,]
                {
                    { 3, 3, new DateTime(2024, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chain Replacement", 35m },
                    { 4, 4, new DateTime(2024, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gear Tuning", 28m },
                    { 5, 5, new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wheel Truing", 40m },
                    { 6, 6, new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seat Adjustment", 15m }
                });

            migrationBuilder.InsertData(
                table: "Faults",
                columns: new[] { "Id", "Comments", "DateResolve", "Description", "RepairId", "VolunteerId" },
                values: new object[,]
                {
                    { 3, "Replaced chain", new DateTime(2024, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chain slipping", 3, 0 },
                    { 4, "Tuned gears", new DateTime(2024, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gears not shifting", 4, 0 },
                    { 5, "Tightened spokes", new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Loose spokes", 5, 0 },
                    { 6, "Adjusted seat post", new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Unstable seat", 6, 0 }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "Cost", "Name", "Quantity", "RepairId" },
                values: new object[,]
                {
                    { 3, 20m, "Chain", 1, 3 },
                    { 4, 5m, "Gear Cable", 1, 4 },
                    { 5, 2m, "Spoke", 4, 5 },
                    { 6, 12m, "Seat Post Clamp", 1, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RepairRecords_VolunteerId",
                table: "RepairRecords",
                column: "VolunteerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RepairRecords");

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Faults",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Volunteers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Volunteers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Volunteers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Volunteers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Bikes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Bikes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Bikes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Bikes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cyclists",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cyclists",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cyclists",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cyclists",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Title",
                value: "Yoga Class");

            migrationBuilder.UpdateData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "Cycling Class");
        }
    }
}
