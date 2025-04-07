namespace MovieDatabaseBlazorServerApp.Models
{
    public class Repair
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        // many to one Bike
        public int BikeID { get; set; }
        public Bike? Bike { get; set; }

        // Add TotalCost property
        public decimal TotalCost { get; set; }

        //one-to-many parts

        public ICollection<Part>? Parts { get; set; } = new List<Part>();


        // one to many Fault

        public ICollection<Fault>? Faults { get; set; } = new List<Fault>();



    }
}