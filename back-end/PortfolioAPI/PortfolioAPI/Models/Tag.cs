using System.ComponentModel.DataAnnotations;
//Author: Oliver Norton

namespace PortfolioAPI.Models;

public class Tag
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public ICollection<ProjectTag> ProjectTags { get; set; }
}