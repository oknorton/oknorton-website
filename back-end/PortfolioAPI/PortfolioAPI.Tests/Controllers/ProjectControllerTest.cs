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

        [Fact]
        public async Task GetProject_ReturnsProjectById()
        {
            // Arrange
            var dbContext = CreateDbContext();
            var fakeProject = new Project
            {
                Id = 1,
                Title = "Project 1",
                Description = "Description 1",
                ImageURL = "ImageURL 1"
            };
            dbContext.Projects.Add(fakeProject);
            dbContext.SaveChanges();

            var controller = new ProjectController(dbContext);

            // Act
            var result = await controller.GetProject(1);

            // Assert
            Assert.NotNull(result);
            if (result.Result is NotFoundResult)
            {
                Assert.IsType<NotFoundResult>(result.Value);
            }
            else
            {
                var project = result.Value as Project;
                Assert.NotNull(project);
                Assert.Equal(fakeProject.Id, project.Id);
                Assert.Equal(fakeProject.Title, project.Title);
                Assert.Equal(fakeProject.Description, project.Description);
                Assert.Equal(fakeProject.ImageURL, project.ImageURL);
            }
        }

        [Fact]
        public async Task PostProject_AddsProject()
        {
            // Arrange
            var dbContext = CreateDbContext();
            var controller = new ProjectController(dbContext);
            var newProject = new Project
            {
                Title = "Project 3",
                Description = "Description 3",
                ImageURL = "ImageURL 3"
            };

            // Act
            var result = await controller.PostProject(newProject);
            var createdResult = result.Result as CreatedAtActionResult;

            // Assert
            Assert.NotNull(createdResult);
            var project = createdResult.Value as Project;
            Assert.NotNull(project);
            Assert.Equal(newProject.Title, project.Title);
            Assert.Equal(newProject.Description, project.Description);
            Assert.Equal(newProject.ImageURL, project.ImageURL);

            var dbProject = await dbContext.Projects.FindAsync(project.Id);
            Assert.NotNull(dbProject);
            Assert.Equal(newProject.Title, dbProject.Title);
            Assert.Equal(newProject.Description, dbProject.Description);
            Assert.Equal(newProject.ImageURL, dbProject.ImageURL);
        }

        [Fact]
        public async Task PutProject_UpdatesExistingProject()
        {
            // Arrange
            var dbContext = CreateDbContext();
            var existingProject = new Project
            {
                Id = 1,
                Title = "Project 1",
                Description = "Description 1",
                ImageURL = "ImageURL 1"
            };
            dbContext.Projects.Add(existingProject);
            dbContext.SaveChanges();

            var controller = new ProjectController(dbContext);
            var updatedProject = new Project
            {
                Id = 1,
                Title = "Updated Project 1",
                Description = "Updated Description 1",
                ImageURL = "Updated ImageURL 1"
            };

            // Act
            var result = await controller.PutProject(1, updatedProject);

            // Assert
            Assert.IsType<NoContentResult>(result);

            var dbProject = await dbContext.Projects.FindAsync(1);
            Assert.NotNull(dbProject);
            Assert.Equal(updatedProject.Title, dbProject.Title);
            Assert.Equal(updatedProject.Description, dbProject.Description);
            Assert.Equal(updatedProject.ImageURL, dbProject.ImageURL);
        }

        [Fact]
        public async Task DeleteProject_RemovesProject()
        {
            // Arrange
            var dbContext = CreateDbContext();
            var existingProject = new Project
            {
                Id = 1,
                Title = "Project 1",
                Description = "Description 1",
                ImageURL = "ImageURL 1"
            };
            dbContext.Projects.Add(existingProject);
            dbContext.SaveChanges();

            var controller = new ProjectController(dbContext);

            // Act
            var result = await controller.DeleteProject(1);

            // Assert
            Assert.IsType<NoContentResult>(result);

            var dbProject = await dbContext.Projects.FindAsync(1);
            Assert.Null(dbProject);
        }
    }
}
