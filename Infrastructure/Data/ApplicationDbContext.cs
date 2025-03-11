using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Hobby> Hobby { get; set; }
        public DbSet<Achivement> Achivements { get; set; }
        public DbSet<Education> educations { get; set; }
        public DbSet<Experience> experiences { get; set; }
        public DbSet<Project> projects { get; set; }
        public DbSet<ProjectTags> ProjectTags { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProjectTags>().HasKey(x => new { x.ProjectID, x.TagID });
            modelBuilder.Entity<ProjectTags>().HasOne(x => x.Project).WithMany(x => x.Tags).HasForeignKey(x => x.ProjectID);
            modelBuilder.Entity<ProjectTags>().HasOne(x => x.Tag).WithMany(x => x.Projects).HasForeignKey(x => x.TagID);
            //Seed Data
            modelBuilder.Entity<Project>().HasData(
                new Project { Title = "Project 1", Description = "Description 1", Link = "https://www.google.com", HasPublicLink = true, ProjectDate = DateTime.Now },
                new Project { Title = "Project 2", Description = "Description 2", Link = "https://www.google.com", HasPublicLink = true, ProjectDate = DateTime.Now },
                new Project { Title = "Project 3", Description = "Description 3", Link = "https://www.google.com", HasPublicLink = true, ProjectDate = DateTime.Now }
            );
            modelBuilder.Entity<Tag>().HasData(
                new Tag { TagName = "Tag 1" },
                new Tag { TagName = "Tag 2" },
                new Tag { TagName = "Tag 3" }
            );

            modelBuilder.Entity<Hobby>().HasData(
                new Hobby { Title = "", Description = "", ImageSrc = "" },
                new Hobby { Title = "", Description = "", ImageSrc = "" },
                new Hobby { Title = "", Description = "", ImageSrc = "" },
                new Hobby { Title = "", Description = "", ImageSrc = "" }
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
