using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieDatabaseBlazorServerApp.Migrations
{
    /// <inheritdoc />
    public partial class adedfields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cyclists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Forename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImageFileName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cyclists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Volunteers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Forename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImageFileName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CyclistId = table.Column<int>(type: "int", nullable: false),
                    RepairId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bikes_Cyclists_CyclistId",
                        column: x => x.CyclistId,
                        principalTable: "Cyclists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CyclistId = table.Column<int>(type: "int", nullable: false),
                    VolunteerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classes_Volunteers_VolunteerId",
                        column: x => x.VolunteerId,
                        principalTable: "Volunteers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Repairs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BikeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repairs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Repairs_Bikes_BikeID",
                        column: x => x.BikeID,
                        principalTable: "Bikes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassCyclist",
                columns: table => new
                {
                    ClassesId = table.Column<int>(type: "int", nullable: false),
                    CyclistsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassCyclist", x => new { x.ClassesId, x.CyclistsId });
                    table.ForeignKey(
                        name: "FK_ClassCyclist_Classes_ClassesId",
                        column: x => x.ClassesId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassCyclist_Cyclists_CyclistsId",
                        column: x => x.CyclistsId,
                        principalTable: "Cyclists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Faults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateResolve = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RepairId = table.Column<int>(type: "int", nullable: false),
                    VolunteerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faults_Repairs_RepairId",
                        column: x => x.RepairId,
                        principalTable: "Repairs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    RepairId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parts_Repairs_RepairId",
                        column: x => x.RepairId,
                        principalTable: "Repairs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FaultVolunteer",
                columns: table => new
                {
                    FaultsResolvedId = table.Column<int>(type: "int", nullable: false),
                    VolunteersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaultVolunteer", x => new { x.FaultsResolvedId, x.VolunteersId });
                    table.ForeignKey(
                        name: "FK_FaultVolunteer_Faults_FaultsResolvedId",
                        column: x => x.FaultsResolvedId,
                        principalTable: "Faults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FaultVolunteer_Volunteers_VolunteersId",
                        column: x => x.VolunteersId,
                        principalTable: "Volunteers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cyclists",
                columns: new[] { "Id", "Address", "DateOfBirth", "Email", "Forename", "ImageFileName", "Phone", "Surname" },
                values: new object[,]
                {
                    { 1, "123 Main St", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", "John", "", "1234567890", "Doe" },
                    { 2, "456 Elm St", new DateTime(1985, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", "Jane", "", "9876543210", "Smith" }
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
                table: "Volunteers",
                columns: new[] { "Id", "Address", "DateOfBirth", "Email", "Forename", "ImageFileName", "Phone", "Surname" },
                values: new object[,]
                {
                    { 1, "789 Oak St", new DateTime(1980, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "alice.johnson@example.com", "Alice", "", "1234567890", "Johnson" },
                    { 2, "456 Pine St", new DateTime(1975, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "bob.smith@example.com", "Bob", "", "9876543210", "Smith" }
                });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "CyclistId", "Make", "Model", "RepairId" },
                values: new object[,]
                {
                    { 1, 1, "Giant", "Defy", 0 },
                    { 2, 2, "Trek", "FX", 0 }
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "CyclistId", "Date", "Title", "VolunteerId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yoga Class", 1 },
                    { 2, 2, new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cycling Class", 2 }
                });

            migrationBuilder.InsertData(
                table: "Repairs",
                columns: new[] { "Id", "BikeID", "Date", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Flat Tire" },
                    { 2, 2, new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brake Adjustment" }
                });

            migrationBuilder.InsertData(
                table: "Faults",
                columns: new[] { "Id", "Comments", "DateResolve", "Description", "RepairId", "VolunteerId" },
                values: new object[,]
                {
                    { 1, "Replaced inner tube", new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Puncture in rear tire", 1, 0 },
                    { 2, "Adjusted brake pads", new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brakes squeaking", 2, 0 }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "Cost", "Name", "Quantity", "RepairId" },
                values: new object[,]
                {
                    { 1, 10.99, "Inner Tube", 1, 1 },
                    { 2, 8.9900000000000002, "Brake Pads", 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bikes_CyclistId",
                table: "Bikes",
                column: "CyclistId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassCyclist_CyclistsId",
                table: "ClassCyclist",
                column: "CyclistsId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_VolunteerId",
                table: "Classes",
                column: "VolunteerId");

            migrationBuilder.CreateIndex(
                name: "IX_Faults_RepairId",
                table: "Faults",
                column: "RepairId");

            migrationBuilder.CreateIndex(
                name: "IX_FaultVolunteer_VolunteersId",
                table: "FaultVolunteer",
                column: "VolunteersId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_RepairId",
                table: "Parts",
                column: "RepairId");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_BikeID",
                table: "Repairs",
                column: "BikeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassCyclist");

            migrationBuilder.DropTable(
                name: "FaultVolunteer");

            migrationBuilder.DropTable(
                name: "Parts");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Faults");

            migrationBuilder.DropTable(
                name: "Volunteers");

            migrationBuilder.DropTable(
                name: "Repairs");

            migrationBuilder.DropTable(
                name: "Bikes");

            migrationBuilder.DropTable(
                name: "Cyclists");

            migrationBuilder.DeleteData(
                table: "Studio",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Studio",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Studio",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
