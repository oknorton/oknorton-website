﻿namespace PortfolioAPI.Models;
//Author: Oliver Norton

public class ProjectTag
{
    public int ProjectId { get; set; }
    public Project Project { get; set; }

    public int TagId { get; set; }
    public Tag Tag { get; set; }
}