using Microsoft.EntityFrameworkCore;
using PortfolioAPI.Models;
//Author: Oliver Norton

namespace PortfolioAPI;

public class PortfolioDbContext : DbContext
{
    private readonly IConfiguration _configuration;


    public PortfolioDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    // Constructor for use with DbContextOptions
    public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : base(options)
    {
    }
    
   
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (_configuration != null)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("PortfolioDatabase"));
        }
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProjectTag>()
            .HasKey(pt => new { pt.ProjectId, pt.TagId });

        modelBuilder.Entity<ProjectTag>()
            .HasOne(pt => pt.Project)
            .WithMany(p => p.ProjectTags)
            .HasForeignKey(pt => pt.ProjectId);

        modelBuilder.Entity<ProjectTag>()
            .HasOne(pt => pt.Tag)
            .WithMany(t => t.ProjectTags)
            .HasForeignKey(pt => pt.TagId);
    }
    
    
    public DbSet<Project> Projects { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<ProjectTag> ProjectTags { get; set; }

}