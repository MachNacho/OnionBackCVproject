using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            //Seed Data
            modelBuilder.Entity<Project>().HasData(
                new Project { ID = 1, Title = "Project 1", Description = "Description 1", Link = "https://www.google.com", HasPublicLink = true, ProjectDate = new DateTime(2023, 1, 15) },
                new Project { ID = 2, Title = "Project 2", Description = "Description 2", Link = "https://www.google.com", HasPublicLink = true, ProjectDate = new DateTime(2023, 1, 15) },
                new Project { ID = 3, Title = "Project 3", Description = "Description 3", Link = "https://www.google.com", HasPublicLink = true, ProjectDate = new DateTime(2023, 1, 15) }
            );
            modelBuilder.Entity<Tag>().HasData(
                new Tag { ID = 1, TagName = "Tag 1" },
                new Tag { ID = 2, TagName = "Tag 2" },
                new Tag { ID = 3, TagName = "Tag 3" }
            );
            modelBuilder.Entity<ProjectTags>().HasData(
                new ProjectTags { ID = 1, ProjectID = 1, TagID = 1 },
                new ProjectTags { ID = 2, ProjectID = 1, TagID = 2 },
                new ProjectTags { ID = 3, ProjectID = 2, TagID = 2 },
                new ProjectTags { ID = 4, ProjectID = 2, TagID = 3 },
                new ProjectTags { ID = 5, ProjectID = 3, TagID = 1 },
                new ProjectTags { ID = 6, ProjectID = 3, TagID = 3 }
            );
            modelBuilder.Entity<Hobby>().HasData(
                new Hobby { ID = 1, Title = "Hobby 1", Description = "Description 1", ImageSrc = "Hobby1.png" },
                new Hobby { ID = 2, Title = "Hobby 2", Description = "Descriptoin 2", ImageSrc = "Hobby2.png" },
                new Hobby { ID = 3, Title = "Hobby 3", Description = "Description 3", ImageSrc = "Hobby3.png" },
                new Hobby { ID = 4, Title = "Hobby 4", Description = "Description 4", ImageSrc = "Hobby4.png" }
            );

            modelBuilder.Entity<Achivement>().HasData(
                new Achivement { ID = 1, Title = "First Milestone", Date = new DateTime(2023, 1, 15), Description = "Completed the first milestone of the project." },
                new Achivement { ID = 2, Title = "Team Award", Date = new DateTime(2023, 5, 20), Description = "Received the team award for outstanding performance." },
                new Achivement { ID = 3, Title = "Product Launch", Date = new DateTime(2023, 9, 10), Description = "Successfully launched the new product." }
            );
            modelBuilder.Entity<Education>().HasData(
                new Education { ID = 1, Title = "Bachelor of Science", EducationLevel = "Undergraduate", Institution = "University of Cape Town", StartDate = new DateTime(2015, 2, 1), EndDate = new DateTime(2018, 11, 30), Description = "Completed a BSc in Computer Science.", ImageSrc = "images/uct.png" },
                new Education { ID = 2, Title = "Master of Science", EducationLevel = "Postgraduate", Institution = "University of Cape Town", StartDate = new DateTime(2019, 2, 1), EndDate = new DateTime(2021, 11, 30), Description = "Completed an MSc in Data Science.", ImageSrc = "images/uct.png" },
                new Education { ID = 3, Title = "PhD in Artificial Intelligence", EducationLevel = "Doctorate", Institution = "University of Cape Town", StartDate = new DateTime(2022, 2, 1), EndDate = new DateTime(2025, 11, 30), Description = "Pursuing a PhD in AI.", ImageSrc = "images/uct.png" }
            );
            modelBuilder.Entity<Experience>().HasData(
                new Experience { ID = 1, Role = "Software Developer", Company = "Company A", StartDate = new DateTime(2018, 1, 1), EndDate = new DateTime(2020, 12, 31), IsCurrent = false, ImageSrc = "images/companyA.png" },
                new Experience { ID = 2, Role = "Data Scientist", Company = "Company B", StartDate = new DateTime(2021, 1, 1), EndDate = null, IsCurrent = true, ImageSrc = "images/companyB.png" },
                new Experience { ID = 3, Role = "AI Researcher", Company = "Company C", StartDate = new DateTime(2022, 1, 1), EndDate = null, IsCurrent = true, ImageSrc = "images/companyC.png" }
            );

        }
    }
}
