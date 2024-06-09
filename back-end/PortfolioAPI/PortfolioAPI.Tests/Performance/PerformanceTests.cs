using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PortfolioAPI.Controllers;
using PortfolioAPI.Models;
using Xunit;

namespace PortfolioAPI.Tests.Performance
{
    public class PerformanceTests
    {
        private readonly DbContextOptions<PortfolioDbContext> _options;

        public PerformanceTests()
        {
            _options = new DbContextOptionsBuilder<PortfolioDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }

        private async Task SeedDatabase(int numberOfProjects)
        {
            using (var context = new PortfolioDbContext(_options))
            {
                for (int i = 0; i < numberOfProjects; i++)
                {
                    context.Projects.Add(new Project
                    {
                        Title = $"Project {i}",
                        Description = $"Description {i}",
                        ImageURL = $"ImageURL {i}"
                    });
                }

                await context.SaveChangesAsync();
            }
        }

        [Fact]
        public async Task GetProjects_SpeedTest()
        {
            const int numberOfProjects = 1000;
            await SeedDatabase(numberOfProjects);

            using (var context = new PortfolioDbContext(_options))
            {
                var controller = new ProjectController(context);

                var stopwatch = Stopwatch.StartNew();

                await controller.GetProjects();

                stopwatch.Stop();

                var elapsedMilliseconds = stopwatch.ElapsedMilliseconds;

                const int maxAllowedMilliseconds = 400;
                Assert.True(elapsedMilliseconds <= maxAllowedMilliseconds,
                    $"GetProjects should complete within {maxAllowedMilliseconds} milliseconds. Elapsed: {elapsedMilliseconds} milliseconds.");
            }
        }
        
        [Fact]
        public async Task GetSingleProjectById_SpeedTest()
        {
            const int numberOfProjects = 100;
            await SeedDatabase(numberOfProjects);

            using (var context = new PortfolioDbContext(_options))
            {
                var controller = new ProjectController(context);

                var stopwatch = Stopwatch.StartNew();

                await controller.GetProject(1);

                stopwatch.Stop();
        
                var elapsedMilliseconds = stopwatch.ElapsedMilliseconds;

                const int maxAllowedMilliseconds = 200;
                Assert.True(elapsedMilliseconds <= maxAllowedMilliseconds, $"GetProject should complete within {maxAllowedMilliseconds} milliseconds. Elapsed: {elapsedMilliseconds} milliseconds.");
            }
        }

    }
}
