using System.ComponentModel.DataAnnotations;

namespace PortfolioAPI.Models;

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
}