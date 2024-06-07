using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace PortfolioAPI.Models
{
    // Author: Oliver Norton
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
        public string ImageURL { get; set; }
        public DateTime Date { get; set; }

        public ICollection<ProjectTag> ProjectTags { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}