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
        }    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProjectTag>()
            .HasKey(pt => new { pt.ProjectId, pt.TagId });

        modelBuilder.Entity<ProjectTag>()
            .HasOne(pt => pt.Project)
            .WithMany(p => p.ProjectTags)
            .HasForeignKey(pt => pt.ProjectId);

        modelBuilder.Entity<ProjectTag>()
            .HasOne(pt => pt.Tag);

        modelBuilder.Entity<Project>()
            .HasOne(p => p.User)
            .WithMany(u => u.Projects)
            .HasForeignKey(p => p.UserId);

        modelBuilder.Entity<SocialInfo>()
            .HasOne(si => si.User)
            .WithMany(u => u.SocialInfos)
            .HasForeignKey(si => si.UserId);
    }
    
    
    public DbSet<Project> Projects { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<ProjectTag> ProjectTags { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<SocialInfo> SocialInfos { get; set; }

}