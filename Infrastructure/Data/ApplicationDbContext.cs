using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
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
