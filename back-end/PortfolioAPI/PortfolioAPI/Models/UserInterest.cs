using System.ComponentModel.DataAnnotations;
//Author: Oliver Norton

namespace PortfolioAPI.Models;

public class UserInterest
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Description { get; set; }
}