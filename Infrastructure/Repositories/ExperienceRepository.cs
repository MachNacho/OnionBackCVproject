using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ExperienceRepository : IExperienceRepository
    {
        private readonly ApplicationDbContext _context;
        public ExperienceRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Experience> Add(Experience experience)
        {
            await _context.experiences.AddAsync(experience);
            await _context.SaveChangesAsync();
            return experience;
        }

        public async Task<Experience> Delete(int id)
        {
            var a = await _context.experiences.FindAsync(id);
            if (a == null) { return null; }
            ;
            _context.experiences.Remove(a);
            await _context.SaveChangesAsync();
            return a;
        }

        public async Task<List<Experience>> GetAll()
        {
            var a = _context.experiences.AsQueryable();
            return await a.ToListAsync();
        }

        public async Task<Experience> Update(int id, Experience experience)
        {
            var a = await _context.experiences.FindAsync(id);
            if (a == null) { return null; }
            await _context.SaveChangesAsync();
            return a;
        }
    }
}
