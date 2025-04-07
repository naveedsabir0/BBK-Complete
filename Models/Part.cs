namespace MovieDatabaseBlazorServerApp.Models
{
    public class Part
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public decimal Cost { get; set; }


        // many to one repair
        public int RepairId { get; set; }
        public Repair Repair { get; set; }
    }
}