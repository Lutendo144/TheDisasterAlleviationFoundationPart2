using System.ComponentModel.DataAnnotations;

namespace TheDisasterAlleviationFoundationPart2.Models
{
    public class MonetaryDonations
    {

        public int DonationID { get; set; }

        public DateTime DonationDate { get; set; }

        
        public decimal Amount { get; set; }

        
        public string DonorName { get; set; }

      
        public bool IsAnonymous { get; set; }
    
    }
}
