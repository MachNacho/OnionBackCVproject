using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class HobbyRepository : IHobbyRepository
    {
        private readonly ApplicationDbContext _context;
        public HobbyRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Hobby> Add(Hobby hobby)
        {
            await _context.Hobby.AddAsync(hobby);
            await _context.SaveChangesAsync();
            return hobby;
        }

        public async Task<Hobby> Delete(int id)
        {
            var a = await _context.Hobby.FindAsync(id);
            if (a == null) { return null; }
            _context.Hobby.Remove(a);
            await _context.SaveChangesAsync();
            return a;
        }

        public async Task<List<Hobby>> GetAll()
        {
            var a = _context.Hobby.AsQueryable();
            return await a.ToListAsync();
        }

        public async Task<Hobby> Update(int id, Hobby hobby)
        {
            var a = await _context.Hobby.FindAsync(id);
            if (a == null) { return null; }
            a.Title = hobby.Title;
            a.Description = hobby.Description;
            a.ImageSrc = hobby.ImageSrc;
            await _context.SaveChangesAsync();
            return a;
        }
    }
}
