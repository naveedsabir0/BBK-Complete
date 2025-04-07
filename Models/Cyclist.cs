using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MovieDatabaseBlazorServerApp.Models
{
    public class Cyclist
    {
        // The Id property uniquely identifies each cyclist in the database.
        public int Id { get; set; }

        // The Forename property represents the first name of the cyclist.
        [Required]
        public string Forename { get; set; }

        // The Surname property represents the last name of the cyclist.
        [Required]
        public string Surname { get; set; }

        // The Name property provides the full name of the cyclist, derived from the Forename and Surname properties.
        public string Name { get => $"{Forename} {Surname}"; }

        // The Email property represents the email address of the cyclist.
        [Required]
        public string Email { get; set; }

        // The Phone property represents the phone number of the cyclist.
        public string Phone { get; set; }

        // The Address property represents the physical address of the cyclist.
        [Required]
        public string Address { get; set; }

        // The DateOfBirth property represents the date of birth of the cyclist.
        [DisplayName("Date Of Birth")]
        public DateTime? DateOfBirth { get; set; }

        // The ImageFileName property represents the file name of the cyclist's photo.
        [Display(Name = "Cyclist's Photo")]
        public string? ImageFileName { get; set; } = string.Empty;

        // The ImageToDeleteFileName property represents the file name of the cyclist's photo to be deleted.
        [NotMapped]
        public string? ImageToDeleteFileName { get; set; } = string.Empty;

        // The Bikes property represents a collection of Bike objects associated with the cyclist.
        // It allows for easy access to all bikes owned by a particular cyclist.
        // This establishes a one-to-many relationship with the Bike entity.
        public ICollection<Bike>? Bikes { get; set; } = new List<Bike>();

        // The IsSelected property is used for UI purposes to indicate if the cyclist is selected.
        [NotMapped]
        public bool IsSelected { get; set; } = false;

        // The Classes property represents a collection of Class objects associated with the cyclist.
        // It allows for easy access to all classes attended by a particular cyclist.
        // This establishes a many-to-many relationship with the Class entity.
        public ICollection<Class>? Classes { get; set; } = new List<Class>();

    }
}
