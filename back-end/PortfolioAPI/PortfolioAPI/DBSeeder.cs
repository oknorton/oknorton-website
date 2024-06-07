using Microsoft.EntityFrameworkCore;
using PortfolioAPI.Models;
using System;
using System.Collections.Generic;

//Author: Oliver Norton

namespace PortfolioAPI
{
    public static class DBSeeder
    {
        public static void Initialize(PortfolioDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var tags = new List<Tag>
            {
                new Tag { Name = "Embedded" }, //0
                new Tag { Name = "HTML" }, //1
                new Tag { Name = "Angular" }, //2
                new Tag { Name = "TypeScript" }, //3
                new Tag { Name = "Frontend" }, //4
                new Tag { Name = "Backend" }, //5
                new Tag { Name = "Full stack" }, //6
                new Tag { Name = "C#" }, //7
                new Tag { Name = "Java" }, //8
                new Tag { Name = "Kotlin" }, //9
                new Tag { Name = "Android" }, //10
                new Tag { Name = "Entity Framework" }, //11
                new Tag { Name = "Arduino" }, //12
                new Tag { Name = "C" }, //13
            };

            context.Tags.AddRange(tags);
            context.SaveChanges();
            
            var users = new List<User>
            {
                new User
                {
                    Name = "Oliver Norton",
                    CurrentOccupation = "A software developer working on various projects",
                    OccupationLocation = "ASML",
                    Bio = "An experienced software developer with a passion for creating impactful projects.",
                    ProfilePictureUrl = "https://example.com/profile.jpg",
                    SocialInfos = new List<SocialInfo>
                    {
                        new SocialInfo { Platform = "GitHub", Url = "https://github.com/olivernorton" },
                        new SocialInfo { Platform = "LinkedIn", Url = "https://linkedin.com/in/olivernorton" }
                    },
                    Projects = new List<Project>
                    {
                        new Project
                        {
                            Title = "Tipsy Trail",
                            Description = "A pub trail application with the best pub crawls for Breda!",
                            ImageURL = "https://i.postimg.cc/mkxgTC1Q/tipsytrail.jpg",
                            Date = DateTime.Now.AddDays(-10),
                            ProjectTags = new List<ProjectTag>
                            {
                                new ProjectTag { TagId = tags[9].Id },
                                new ProjectTag { TagId = tags[10].Id }
                            }
                        },
                        new Project
                        {
                            Title = "Zazu",
                            Description =
                                "A platform focused at increasing stakeholder improvement for better results.",
                            ImageURL = "https://i.postimg.cc/FRSDfXz2/project.png",
                            Date = DateTime.Now.AddDays(-9),
                            ProjectTags = new List<ProjectTag>
                            {
                                new ProjectTag { TagId = tags[1].Id },
                                new ProjectTag { TagId = tags[2].Id }
                            }
                        },

                        new Project
                        {
                            Title = "Boebot",
                            Description =
                                "An autonomous robot system capable of object detection, mobility, and remote controlled input",
                            ImageURL = "https://i.postimg.cc/dtLWDF1J/boebot.png",
                            Date = DateTime.Now.AddDays(-9),
                            ProjectTags = new List<ProjectTag>
                            {
                                new ProjectTag { TagId = tags[13].Id },
                                new ProjectTag { TagId = tags[12].Id }
                            }
                        },
                        new Project
                        {
                            Title = "Mobile Healthcare",
                            Description =
                                "A remote client server health management system allowing medical professionals to monitor a patient's vitals from a remote location",
                            ImageURL = "https://i.postimg.cc/CKn5KmBv/mobilehealthcare.png",
                            Date = DateTime.Now.AddDays(-9),
                            ProjectTags = new List<ProjectTag>
                            {
                                new ProjectTag { TagId = tags[6].Id },
                                new ProjectTag { TagId = tags[7].Id }
                            }
                        },
                        new Project
                        {
                            Title = "Portfolio Website",
                            Description =
                                "A dynamic portfolio website to showcase experience, contact and personal information about Oliver Norton",
                            ImageURL = "https://i.postimg.cc/3Rq8r6W4/Screenshot-2024-03-23-193251.png",
                            Date = DateTime.Now.AddDays(-9),
                            ProjectTags = new List<ProjectTag>
                            {
                                new ProjectTag { TagId = tags[1].Id },
                                new ProjectTag { TagId = tags[2].Id },
                                new ProjectTag { TagId = tags[6].Id },
                                new ProjectTag { TagId = tags[11].Id },
                            }
                        },
                        new Project
                        {
                            Title = "Another Project",
                            Description = "A completely made up placeholder project",
                            ImageURL =
                                "https://www.schoolofsciencery.com/wp-content/uploads/2023/02/Project-Management-Post.jpg",
                            Date = DateTime.Now.AddDays(-9),
                            ProjectTags = new List<ProjectTag>
                            {
                                new ProjectTag { TagId = tags[1].Id },
                                new ProjectTag { TagId = tags[2].Id }
                            }
                        },
                        new Project
                        {
                            Title = "Another Project 2",
                            Description = "A completely made up placeholder project",
                            ImageURL =
                                "https://www.schoolofsciencery.com/wp-content/uploads/2023/02/Project-Management-Post.jpg",
                            Date = DateTime.Now.AddDays(-9),
                            ProjectTags = new List<ProjectTag>
                            {
                                new ProjectTag { TagId = tags[1].Id },
                                new ProjectTag { TagId = tags[2].Id }
                            }
                        },
                    },
                    Interests = new List<UserInterest>
                    {
                        new UserInterest { Description = "Test 1" },
                        new UserInterest { Description = "Test 2" },
                        new UserInterest { Description = "Test 3" },
                        new UserInterest { Description = "Test 4" }

                    }

                }
            };
            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}