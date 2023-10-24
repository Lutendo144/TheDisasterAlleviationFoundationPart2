using System.ComponentModel.DataAnnotations;

namespace TheDisasterAlleviationFoundationPart2.Models
{
    public class Disasters
    {
     


        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public string RequiredAidTypes { get; set; }
    }
}
