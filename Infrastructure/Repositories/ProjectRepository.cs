using Domain.Contracts;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.JsonPatch;
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

        public async Task<bool> Delete(int id)
        {
            var a = await _context.projects.FindAsync(id);
            if (a == null) { return null; }
            _context.projects.Remove(a);
            await _context.SaveChangesAsync();
            return a;
        }

        public async Task<List<Project>> GetAll()
        {
            return await _context.projects.Include(a => a.Tags).ThenInclude(pt => pt.Tag).AsQueryable().ToListAsync();
        }

        public async Task<Project> Update(int id, JsonPatchDocument<Project> project)
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
