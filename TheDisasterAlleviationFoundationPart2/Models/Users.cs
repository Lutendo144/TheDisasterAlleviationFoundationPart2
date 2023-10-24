using System.ComponentModel.DataAnnotations;

namespace TheDisasterAlleviationFoundationPart2.Models
{
    public class Users
    { 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

}

