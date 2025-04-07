using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieDatabaseBlazorServerApp.Models;

namespace MovieDatabaseBlazorServerApp.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {


        public DbSet<Cyclist> Cyclists { get; set; }
        public DbSet<Bike> Bikes { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<Repair> Repairs { get; set; }
        public DbSet<Fault> Faults { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<RepairRecord> RepairRecords { get; set; }
        public DbSet<UploadedFile> UploadedFile { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfiguration Configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .AddEnvironmentVariables()
                    .Build();

                optionsBuilder
                    .UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                    .EnableSensitiveDataLogging()
                    .LogTo(x => System.Diagnostics.Debug.WriteLine(x));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Adding sample data for Cyclist entity
            modelBuilder.Entity<Cyclist>().HasData(
                new Cyclist { Id = 1, Forename = "John", Surname = "Doe", Email = "john.doe@example.com", Phone = "1234567890", Address = "123 Main St", DateOfBirth = new DateTime(1990, 1, 1) },
                new Cyclist { Id = 2, Forename = "Jane", Surname = "Smith", Email = "jane.smith@example.com", Phone = "9876543210", Address = "456 Elm St", DateOfBirth = new DateTime(1985, 5, 10) },
                new Cyclist { Id = 3, Forename = "Tom", Surname = "Harris", Email = "tom.harris@example.com", Phone = "1112223333", Address = "789 Birch St", DateOfBirth = new DateTime(1992, 2, 20) },
                new Cyclist { Id = 4, Forename = "Lucy", Surname = "Brown", Email = "lucy.brown@example.com", Phone = "2223334444", Address = "321 Maple St", DateOfBirth = new DateTime(1988, 11, 30) },
                new Cyclist { Id = 5, Forename = "Mark", Surname = "Wilson", Email = "mark.wilson@example.com", Phone = "3334445555", Address = "654 Cedar St", DateOfBirth = new DateTime(1979, 7, 14) },
                new Cyclist { Id = 6, Forename = "Emma", Surname = "Green", Email = "emma.green@example.com", Phone = "4445556666", Address = "987 Ash St", DateOfBirth = new DateTime(1995, 3, 25) }
            );

            // Adding sample data for Bike entity
            modelBuilder.Entity<Bike>().HasData(
                new Bike { Id = 1, Make = "Giant", Model = "Defy", CyclistId = 1 },
                new Bike { Id = 2, Make = "Trek", Model = "FX", CyclistId = 2 },
                new Bike { Id = 3, Make = "Specialized", Model = "Allez", CyclistId = 3 },
                new Bike { Id = 4, Make = "Cannondale", Model = "Synapse", CyclistId = 4 },
                new Bike { Id = 5, Make = "Bianchi", Model = "Impulso", CyclistId = 5 },
                new Bike { Id = 6, Make = "Scott", Model = "Speedster", CyclistId = 6 }
            );

            // Adding sample data for Class entity
            modelBuilder.Entity<Class>().HasData(
                new Class { Id = 1, Title = "Bike Maintenance", Date = new DateOnly(2024, 5, 1), CyclistId = 1, VolunteerId = 1 },
                new Class { Id = 2, Title = "Road Safety", Date = new DateOnly(2024, 5, 2), CyclistId = 2, VolunteerId = 2 },
                new Class { Id = 3, Title = "Mountain Biking Basics", Date = new DateOnly(2024, 5, 3), CyclistId = 3, VolunteerId = 3 },
                new Class { Id = 4, Title = "Advanced Cycling Techniques", Date = new DateOnly(2024, 5, 4), CyclistId = 4, VolunteerId = 4 },
                new Class { Id = 5, Title = "Cycling Endurance Training", Date = new DateOnly(2024, 5, 5), CyclistId = 5, VolunteerId = 5 },
                new Class { Id = 6, Title = "Urban Cycling Tips", Date = new DateOnly(2024, 5, 6), CyclistId = 6, VolunteerId = 6 }
            );

            // Adding sample data for Volunteer entity
            modelBuilder.Entity<Volunteer>().HasData(
                new Volunteer { Id = 1, Forename = "Alice", Surname = "Johnson", Email = "alice.johnson@example.com", Phone = "1234567890", Address = "789 Oak St", DateOfBirth = new DateTime(1980, 3, 15) },
                new Volunteer { Id = 2, Forename = "Bob", Surname = "Smith", Email = "bob.smith@example.com", Phone = "9876543210", Address = "456 Pine St", DateOfBirth = new DateTime(1975, 6, 20) },
                new Volunteer { Id = 3, Forename = "Clara", Surname = "Davis", Email = "clara.davis@example.com", Phone = "5556667777", Address = "654 Willow St", DateOfBirth = new DateTime(1990, 9, 18) },
                new Volunteer { Id = 4, Forename = "David", Surname = "Martin", Email = "david.martin@example.com", Phone = "6667778888", Address = "321 Chestnut St", DateOfBirth = new DateTime(1983, 12, 22) },
                new Volunteer { Id = 5, Forename = "Ella", Surname = "Clark", Email = "ella.clark@example.com", Phone = "7778889999", Address = "987 Walnut St", DateOfBirth = new DateTime(1978, 4, 10) },
                new Volunteer { Id = 6, Forename = "Frank", Surname = "Garcia", Email = "frank.garcia@example.com", Phone = "8889990000", Address = "123 Poplar St", DateOfBirth = new DateTime(1992, 6, 5) }
            );

            // Adding sample data for Repair entity
            modelBuilder.Entity<Repair>().HasData(
                new Repair { Id = 1, Title = "Flat Tire", Date = new DateTime(2024, 5, 1), BikeID = 1, TotalCost = 43 },
                new Repair { Id = 2, Title = "Brake Adjustment", Date = new DateTime(2024, 5, 2), BikeID = 2, TotalCost = 23 },
                new Repair { Id = 3, Title = "Chain Replacement", Date = new DateTime(2024, 5, 3), BikeID = 3, TotalCost = 35 },
                new Repair { Id = 4, Title = "Gear Tuning", Date = new DateTime(2024, 5, 4), BikeID = 4, TotalCost = 28 },
                new Repair { Id = 5, Title = "Wheel Truing", Date = new DateTime(2024, 5, 5), BikeID = 5, TotalCost = 40 },
                new Repair { Id = 6, Title = "Seat Adjustment", Date = new DateTime(2024, 5, 6), BikeID = 6, TotalCost = 15 }
            );

            // Adding sample data for Fault entity
            modelBuilder.Entity<Fault>().HasData(
                new Fault { Id = 1, Description = "Puncture in rear tire", DateResolve = new DateTime(2024, 5, 1), Comments = "Replaced inner tube", RepairId = 1 },
                new Fault { Id = 2, Description = "Brakes squeaking", DateResolve = new DateTime(2024, 5, 2), Comments = "Adjusted brake pads", RepairId = 2 },
                new Fault { Id = 3, Description = "Chain slipping", DateResolve = new DateTime(2024, 5, 3), Comments = "Replaced chain", RepairId = 3 },
                new Fault { Id = 4, Description = "Gears not shifting", DateResolve = new DateTime(2024, 5, 4), Comments = "Tuned gears", RepairId = 4 },
                new Fault { Id = 5, Description = "Loose spokes", DateResolve = new DateTime(2024, 5, 5), Comments = "Tightened spokes", RepairId = 5 },
                new Fault { Id = 6, Description = "Unstable seat", DateResolve = new DateTime(2024, 5, 6), Comments = "Adjusted seat post", RepairId = 6 }
            );

            // Adding sample data for Part entity
            modelBuilder.Entity<Part>().HasData(
                new Part { Id = 1, Name = "Inner Tube", Quantity = 1, Cost = 10, RepairId = 1 },
                new Part { Id = 2, Name = "Brake Pads", Quantity = 2, Cost = 8, RepairId = 2 },
                new Part { Id = 3, Name = "Chain", Quantity = 1, Cost = 20, RepairId = 3 },
                new Part { Id = 4, Name = "Gear Cable", Quantity = 1, Cost = 5, RepairId = 4 },
                new Part { Id = 5, Name = "Spoke", Quantity = 4, Cost = 2, RepairId = 5 },
                new Part { Id = 6, Name = "Seat Post Clamp", Quantity = 1, Cost = 12, RepairId = 6 }
            );
        }

    }
}
