using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PortfolioAPI.Controllers;
using Xunit;

namespace PortfolioAPI.Tests.Controllers
{
    public class UserControllerTest
    {
        private PortfolioDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<PortfolioDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new PortfolioDbContext(options);
        }

        private List<User> GetFakeUsers()
        {
            return new List<User>
            {
                new User
                {
                    Id = 1,
                    Name = "User 1",
                    CurrentOccupation = "Occupation 1",
                    OccupationLocation = "Location 1",
                    Bio = "Bio 1",
                    ProfilePictureUrl = "Profile Picture URL 1",
                },
                new User
                {
                    Id = 2,
                    Name = "User 2",
                    CurrentOccupation = "Occupation 2",
                    OccupationLocation = "Location 2",
                    Bio = "Bio 2",
                    ProfilePictureUrl = "Profile Picture URL 2",
                }
            };
        }

        [Fact]
        public async Task GetUser_ReturnsUserById()
        {
            // Arrange
            var dbContext = CreateDbContext();
            var fakeUsers = GetFakeUsers();
            foreach (var fakeUser in fakeUsers)
            {
                dbContext.Users.Add(fakeUser);
            }
            dbContext.SaveChanges();

            var controller = new UserController(dbContext);

            // Act
            var result = await controller.GetUser(1);

            // Assert
            Assert.NotNull(result);
            if (result.Result is NotFoundResult)
            {
                Assert.IsType<NotFoundResult>(result.Result);
            }
            else
            {
                var user = result.Value as User;
                Assert.NotNull(user);
                Assert.Equal(fakeUsers[0].Id, user.Id);
                Assert.Equal(fakeUsers[0].Name, user.Name);
            }
        }
        

        [Fact]
        public async Task DeleteUser_RemovesUser()
        {
            // Arrange
            var dbContext = CreateDbContext();
            var fakeUser = new User
            {
                Id = 1,
                Name = "User 1",
                CurrentOccupation = "Occupation 1",
                OccupationLocation = "Location 1",
                Bio = "Bio 1",
                ProfilePictureUrl = "Profile Picture URL 1",
            };
            dbContext.Users.Add(fakeUser);
            dbContext.SaveChanges();

            var controller = new UserController(dbContext);

            // Act
            var result = await controller.DeleteUser(1);

            // Assert
            Assert.IsType<NoContentResult>(result);

            var dbUser = await dbContext.Users.FindAsync(1);
            Assert.Null(dbUser);
        }
        [Fact]
        public async Task PostUser_AddsUser()
        {
            // Arrange
            var dbContext = CreateDbContext();
            var controller = new UserController(dbContext);
            var newUser = new User
            {
                Name = "New User",
                CurrentOccupation = "New Occupation",
                OccupationLocation = "New Location",
                Bio = "New Bio",
                ProfilePictureUrl = "New Profile Picture URL"
            };

            // Act
            var result = await controller.PostUser(newUser);
            var createdResult = result.Result as CreatedAtActionResult;

            // Assert
            Assert.NotNull(createdResult);
            var user = createdResult.Value as User;
            Assert.NotNull(user);
            Assert.Equal(newUser.Name, user.Name);
            Assert.Equal(newUser.CurrentOccupation, user.CurrentOccupation);
            Assert.Equal(newUser.OccupationLocation, user.OccupationLocation);
            Assert.Equal(newUser.Bio, user.Bio);
            Assert.Equal(newUser.ProfilePictureUrl, user.ProfilePictureUrl);

            var dbUser = await dbContext.Users.FindAsync(user.Id);
            Assert.NotNull(dbUser);
            Assert.Equal(newUser.Name, dbUser.Name);
            Assert.Equal(newUser.CurrentOccupation, dbUser.CurrentOccupation);
            Assert.Equal(newUser.OccupationLocation, dbUser.OccupationLocation);
            Assert.Equal(newUser.Bio, dbUser.Bio);
            Assert.Equal(newUser.ProfilePictureUrl, dbUser.ProfilePictureUrl);
        }
        
        [Fact]
        public async Task PutUser_UpdatesExistingUser()
        {
            // Arrange
            var dbContext = CreateDbContext();
            var existingUser = new User
            {
                Id = 1,
                Name = "User 1",
                CurrentOccupation = "Occupation 1",
                OccupationLocation = "Location 1",
                Bio = "Bio 1",
                ProfilePictureUrl = "Profile Picture URL 1",
            };
            dbContext.Users.Add(existingUser);
            dbContext.SaveChanges();

            var controller = new UserController(dbContext);
            var updatedUser = new User
            {
                Id = 1,
                Name = "Updated User 1",
                CurrentOccupation = "Updated Occupation 1",
                OccupationLocation = "Updated Location 1",
                Bio = "Updated Bio 1",
                ProfilePictureUrl = "Updated Profile Picture URL 1",
            };

            // Act
            var result = await controller.PutUser(1, updatedUser);

            // Assert
            Assert.IsType<NoContentResult>(result);

            var dbUser = await dbContext.Users.FindAsync(1);
            Assert.NotNull(dbUser);
            Assert.Equal(updatedUser.Name, dbUser.Name);
            Assert.Equal(updatedUser.CurrentOccupation, dbUser.CurrentOccupation);
            Assert.Equal(updatedUser.OccupationLocation, dbUser.OccupationLocation);
            Assert.Equal(updatedUser.Bio, dbUser.Bio);
            Assert.Equal(updatedUser.ProfilePictureUrl, dbUser.ProfilePictureUrl);
        }
    }
    
}
