namespace MovieDatabaseBlazorServerApp.Models
{
    public class Fault
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime DateResolve { get; set; }

        public string Comments { get; set; }


        // many to one repair
        public int RepairId { get; set; }
        public Repair? Repair { get; set; }


        // many to many Volunteer
        public int VolunteerId { get; set; }
        public ICollection<Volunteer> Volunteers { get; set; } = new List<Volunteer>();



    }
}