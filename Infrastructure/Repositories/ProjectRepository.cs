using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _context;
        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Project> Add(Project project)
        {
            await _context.projects.AddAsync(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<Project> Delete(int id)
        {
            var a = await _context.projects.FindAsync(id);
            if (a == null) { return null; }
            _context.projects.Remove(a);
            await _context.SaveChangesAsync();
            return a;
        }

        public async Task<List<Project>> GetAll()
        {
            var a = _context.projects.AsQueryable();
            return await a.ToListAsync();
        }

        public async Task<Project> Update(int id ,Project project)
        {
            var a = await _context.projects.FindAsync(id);
            if (a == null) { return null; }
            a.Title = project.Title;
            a.Description = project.Description;
            a.ProjectDate = project.ProjectDate;
            a.Link = project.Link;
            a.HasPublicLink = project.HasPublicLink;
            await _context.SaveChangesAsync();
            return a;
        }
    }
}
