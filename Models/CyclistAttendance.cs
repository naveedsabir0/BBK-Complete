namespace MovieDatabaseBlazorServerApp.Models
{
    public class CyclistAttendance
    {
        // The CyclistID property represents the unique identifier of the cyclist.
        public int CyclistID { get; set; }

        // The CyclistName property represents the name of the cyclist.
        public string CyclistName { get; set; }

        // The DateOfClass property represents the date of the class attended by the cyclist.
        public DateOnly DateOfClass { get; set; }

        // The Class property holds information about the class attended by the cyclist.
        // It may include details such as the title or name of the class.
        public string Class { get; set; } // Class information

        // The VolunteerName property holds information about the volunteer overseeing the class.
        // This property is optional and may be present if the data is grouped by volunteer.
        public string VolunteerName { get; set; } // Volunteer information (optional if grouped by volunteer)

        // The NumberOfCyclists property represents the number of cyclists who attended the class.
        public int NumberOfCyclists { get; set; } // Number of cyclists attended
    }
}
