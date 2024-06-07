using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace PortfolioAPI.Models
{
    // Author: Oliver Norton
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string CurrentOccupation { get; set; }
        public string OccupationLocation { get; set; }
        public string Bio { get; set; }
        public string ProfilePictureUrl { get; set; }

        public ICollection<SocialInfo> SocialInfos { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<UserInterest> Interests { get; set; }

    }
}