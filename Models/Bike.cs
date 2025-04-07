namespace MovieDatabaseBlazorServerApp.Models
{
    public class Bike
    {
        // The Id property uniquely identifies each bike in the database.
        public int Id { get; set; }

        // The Make property represents the brand or manufacturer of the bike.
        public string Make { get; set; }

        // The Model property represents the specific model of the bike.
        public string Model { get; set; }

        // The CyclistId property establishes a many-to-one relationship with the Cyclist entity.
        // It holds the foreign key value referencing the associated cyclist.
        public int CyclistId { get; set; }

        // The Cyclist navigation property allows direct access to the associated cyclist object.
        public Cyclist Cyclist { get; set; }

        // The RepairId property is used for establishing a many-to-many relationship with the Repair entity.
        // It's typically not used directly in code but is part of the database schema.
        public int RepairId { get; set; }

        // The Repairs property represents a collection of Repair objects associated with the bike.
        // It allows for easy access to all repairs related to a particular bike.
        public ICollection<Repair>? Repairs { get; set; } = new List<Repair>();
    }
}
