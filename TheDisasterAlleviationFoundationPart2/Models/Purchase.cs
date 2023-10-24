namespace TheDisasterAlleviationFoundationPart2.Models
{
    public class Purchase
    {

        public decimal Amount { get; set; }
        public string Description { get; set; }
        public int DisasterId { get; set; } // Reference to the Disaster for allocation

        public Disasters Disaster { get; set; }
    }

}
