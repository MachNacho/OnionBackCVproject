using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Infrastructure.Exceptions;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class HobbyRepository : IHobbyRepository
    {
        private readonly ApplicationDbContext _context;
        public HobbyRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new DatabaseConnectionException("Context is null");
        }
        public async Task<bool> Add(Hobby hobby)
        {
            try
            {
                await _context.Hobby.AddAsync(hobby);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var a = await _context.Hobby.FindAsync(id);
                if (a == null) { return false; }
                _context.Hobby.Remove(a);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception) { return false; }

        }

        public async Task<List<Hobby>> GetAll()
        {
            var r = await _context.Hobby.AsNoTracking().ToListAsync(); // Prevents EF from tracking objects in memeory
            return r.Count == 0 ? null : r;
        }

        public async Task<Hobby> Update(int id, JsonPatchDocument<Hobby> hobby)
        {
            var a = await _context.Hobby.FindAsync(id);
            if (a == null) { return null; }
            hobby.ApplyTo(a);
            await _context.SaveChangesAsync();
            return a;
        }
    }
}
