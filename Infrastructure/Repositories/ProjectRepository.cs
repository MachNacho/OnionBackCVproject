using Domain.Contracts;
using Domain.Entities;
using Domain.Exceptions;
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
            try
            {
                await _context.projects.AddAsync(project);
                await _context.SaveChangesAsync();
                return project;
            }
            catch (Exception)
            {
                throw new BusinessRuleViolationException($"Value {project} can't be added");
            }

        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var a = await _context.projects.FindAsync(id);
                _context.projects.Remove(a);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw new NotFoundException($"The ID: {id} isn't found in the records");
            }
        }

        public async Task<List<Project>> GetAll()
        {
            var r = await _context.projects.Include(x=>x.Tags).ThenInclude(p=>p.Tag).AsNoTracking().ToListAsync(); // Prevents EF from tracking objects in memeory
            return r.Count == 0 ? throw new EmptyOrNoRecordsException("No hobby exists") : r;
        }

        public async Task<Project> Update(int id, JsonPatchDocument<Project> project)
        {
            try
            {
                var a = await _context.projects.FindAsync(id);
                if (a == null) { throw new NotFoundException($"The ID: {id} isn't found in the records"); }
                project.ApplyTo(a);
                await _context.SaveChangesAsync();
                return a;
            }
            catch (Exception)
            {
                throw new BusinessRuleViolationException($"Value can't be updated");
            }
        }
    }
}
