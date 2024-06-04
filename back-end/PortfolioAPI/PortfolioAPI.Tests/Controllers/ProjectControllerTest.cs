using Microsoft.EntityFrameworkCore;
using PortfolioAPI;
using PortfolioAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using PortfolioAPI.Controllers;

namespace PortfolioAPI.Tests.Controllers
{
    public class ProjectControllerTest
    {
        private PortfolioDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<PortfolioDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new PortfolioDbContext(options);
        }

        [Fact]
        public async Task GetProjects_ReturnsAllProjects()
        {
            // Arrange
            var dbContext = CreateDbContext();
            foreach (var fakeProject in GetFakeProjects())
            {
                dbContext.Projects.Add(fakeProject);
            }
            dbContext.SaveChanges();

            var controller = new ProjectController(dbContext);
            var expectedProjects = GetFakeProjects();

            // Act
            var result = await controller.GetProjects();
            var okResult = result.Result as OkObjectResult;

            // Assert
            Assert.NotNull(okResult);
            var projects = okResult.Value as List<Project>;
            Assert.NotNull(projects);
            Assert.Equal(expectedProjects.Count, projects.Count);

            for (int i = 0; i < expectedProjects.Count; i++)
            {
                Assert.Equal(expectedProjects[i].Id, projects[i].Id);
                Assert.Equal(expectedProjects[i].Title, projects[i].Title);
                Assert.Equal(expectedProjects[i].Description, projects[i].Description);
                Assert.Equal(expectedProjects[i].ImageURL, projects[i].ImageURL);
            }
        }

        private List<Project> GetFakeProjects()
        {
            return new List<Project>
            {
                new Project
                {
                    Id = 1,
                    Title = "Project 1",
                    Description = "Description 1",
                    ImageURL = "ImageURL 1",
                },
                new Project
                {
                    Id = 2,
                    Title = "Project 2",
                    Description = "Description 2",
                    ImageURL = "ImageURL 2",
                }
            };
        }
    }
}
