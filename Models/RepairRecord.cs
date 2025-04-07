using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MovieDatabaseBlazorServerApp.Models
{
    public class RepairRecord
    {
        // The Id property serves as the primary key for the RepairRecord entity.
        [Key]
        public int Id { get; set; }

        // The VolunteerId property represents the foreign key referencing the associated volunteer.
        [Required]
        public int VolunteerId { get; set; }

        // The ForeignKey attribute specifies that the VolunteerId property is a foreign key.
        [ForeignKey("VolunteerId")]
        public Volunteer Volunteer { get; set; }

        // The RepairDate property represents the date when the repair was conducted.
        [Required]
        public DateTime RepairDate { get; set; }

        // The RepairTime property represents the time taken to complete the repair, in minutes.
        [Required]
        public int RepairTime { get; set; }
    }
}
