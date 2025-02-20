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

    }
}
