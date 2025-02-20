using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AchivementRepository : IAchivementRepository
    {
        private readonly ApplicationDbContext _context;
        public AchivementRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Achivement> Add(Achivement achivement)
        {
            await _context.Achivements.AddAsync(achivement);
            await _context.SaveChangesAsync();
            return achivement;
        }

        public async Task<Achivement> Delete(int id)
        {
            var a = await _context.Achivements.FindAsync(id);
            if (a == null) { return null; }
            _context.Achivements.Remove(a);
            await _context.SaveChangesAsync();
            return a;
        }

        public async Task<List<Achivement>> GetAll()
        {
            var a = _context.Achivements.AsQueryable();
            return await a.ToListAsync();
        }

        public async Task<Achivement> Update(int id, Achivement achivement)
        {
            var a = _context.Achivements.Find(id);
            if (a == null) { return null; }
            a.Title = achivement.Title;
            a.Date = achivement.Date;
            a.Description = achivement.Description;
            _context.SaveChanges();
            return a;
        }
    }
}
