namespace MovieDatabaseBlazorServerApp.Models
{
    public class Class
    {
        // The Id property uniquely identifies each class in the database.
        public int Id { get; set; }

        // The Title property represents the title or name of the class.
        public string Title { get; set; }

        // The Date property represents the date of the class.
        public DateOnly Date { get; set; }

        // The AttendanceCount property tracks the number of attendees in the class.

        // The CyclistId property is used for establishing a many-to-many relationship with the Cyclist entity.
        // It's typically not used directly in code but is part of the database schema.

        // The Cyclists property represents a collection of Cyclist objects associated with the class.
        // It allows for easy access to all cyclists participating in a particular class.

        // The VolunteerId property establishes a many-to-one relationship with the Volunteer entity.
        // It holds the foreign key value referencing the associated volunteer.

        // The Volunteer navigation property allows direct access to the associated volunteer object.
        public int AttendanceCount { get; set; }

        // many to many cyclist
        public int CyclistId { get; set; }
        public ICollection<Cyclist> Cyclists { get; set; } = new List<Cyclist>();

        // many to one volunteer
        public int VolunteerId { get; set; }
        public Volunteer Volunteer { get; set; }
    }
}
