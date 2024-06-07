using System.ComponentModel.DataAnnotations;

namespace PortfolioAPI.Models
{
    // Author: Oliver Norton
    public class SocialInfo
    {
        [Key]
        public int Id { get; set; }

        public string Platform { get; set; } 
        public string Url { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}