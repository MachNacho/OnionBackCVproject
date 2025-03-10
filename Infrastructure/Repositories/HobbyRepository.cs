using Domain.Contracts;
using Domain.Entities;
using Domain.Exceptions;
using Infrastructure.Data;
using Microsoft.AspNetCore.JsonPatch;
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
                throw new BusinessRuleViolationException($"Value {hobby.Title} can't be added");
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var a = await _context.Hobby.FindAsync(id);
                _context.Hobby.Remove(a);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw new NotFoundException($"The ID: {id} isn't found in the records");
            }

        }

        public async Task<List<Hobby>> GetAll()
        {
            var r = await _context.Hobby.AsNoTracking().ToListAsync(); // Prevents EF from tracking objects in memeory
            return r.Count == 0 ? throw new EmptyOrNoRecordsException("No hobby exists") : r;
        }

        public async Task<Hobby?> Update(int id, JsonPatchDocument<Hobby> hobby)
        {
            try
            {
                var a = await _context.Hobby.FindAsync(id);
                if (a == null) { throw new NotFoundException($"The ID: {id} isn't found in the records"); }
                hobby.ApplyTo(a);
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
