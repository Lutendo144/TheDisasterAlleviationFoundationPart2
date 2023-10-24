using System.ComponentModel.DataAnnotations;

namespace TheDisasterAlleviationFoundationPart2.Models
{
    public class GoodsDonations
    {
     

       
        public DateTime DonationDate { get; set; }

      
        public int NumberOfItems { get; set; }

      
        public string Description { get; set; }

       
        public string DonorName { get; set; }

       
        public bool IsAnonymous { get; set; }
    }
}
