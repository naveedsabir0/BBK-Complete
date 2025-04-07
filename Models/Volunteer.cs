using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDatabaseBlazorServerApp.Models
{
    public class Volunteer
    {
        // The Id property uniquely identifies each volunteer in the database.
        public int Id { get; set; }

        // The Forename property represents the first name of the volunteer.
        [Required]
        public string Forename { get; set; }

        // The Surname property represents the last name of the volunteer.
        [Required]
        public string Surname { get; set; }

        // The Name property provides the full name of the volunteer, derived from the Forename and Surname properties.
        public string Name { get => $"{Forename} {Surname}"; }

        // The Email property represents the email address of the volunteer.
        [Required]
        public string Email { get; set; }

        // The Phone property represents the phone number of the volunteer.
        public string Phone { get; set; }

        // The Address property represents the physical address of the volunteer.
        [Required]
        public string Address { get; set; }

        // The DateOfBirth property represents the date of birth of the volunteer.
        [DisplayName("Date Of Birth")]
        public DateTime? DateOfBirth { get; set; }

        // The ImageFileName property represents the file name of the volunteer's photo.
        public string? ImageFileName { get; set; } = string.Empty;

        // The ImageToDeleteFileName property represents the file name of the volunteer's photo to be deleted.
        [NotMapped]
        public string? ImageToDeleteFileName { get; set; } = string.Empty;

        // The IsSelected property is used for UI purposes to indicate if the volunteer is selected.
        [NotMapped]
        public bool IsSelected { get; set; } = false;

        // The ClassesGiven property represents a collection of Class objects associated with the volunteer.
        // It allows for easy access to all classes conducted by a particular volunteer.
        // This establishes a one-to-many relationship with the Class entity.
        public ICollection<Class>? ClassesGiven { get; set; } = new List<Class>();

        // The FaultsResolved property represents a collection of Fault objects associated with the volunteer.
        // It allows for easy access to all faults resolved by a particular volunteer.
        // This establishes a many-to-many relationship with the Fault entity.
        public ICollection<Fault>? FaultsResolved { get; set; } = new List<Fault>();
    }
}
