namespace TheDisasterAlleviationFoundationPart2.Models
{
    public class DonationManager
    {
      public List<MonetaryDonations> MonetaryDonations { get; set; }
        public List<GoodsDonations> GoodsDonations { get; set;}
        public List<Disasters> Disasters { get; set; } = new List<Disasters>();

    }
}
