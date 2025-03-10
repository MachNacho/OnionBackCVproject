using Domain.Contracts;
using Domain.Entities;
using Domain.Exceptions;
using Infrastructure.Data;
using Microsoft.AspNetCore.JsonPatch;
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
            try
            {
                await _context.Achivements.AddAsync(achivement);
                await _context.SaveChangesAsync();
                return achivement;
            }
            catch (Exception)
            {
                throw new BusinessRuleViolationException($"Value {achivement.Title} can't be added");
            }

        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                var a = await _context.Achivements.FindAsync(id);
                _context.Achivements.Remove(a);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw new NotFoundException($"The ID: {id} isn't found in the records");
            }
        }
        public async Task<List<Achivement>> GetAll()
        {
            var a = await _context.Achivements.AsNoTracking().ToListAsync();// Prevents EF from tracking objects in memory
            return a.Count == 0 ? throw new EmptyOrNoRecordsException("No hobby exists") : a;
        }
        public async Task<Achivement> Update(int id, JsonPatchDocument<Achivement> ach)
        {
            try
            {
                var a = _context.Achivements.Find(id);
                if (a == null) { throw new NotFoundException($"The ID: {id} isn't found in the records"); }
                ach.ApplyTo(a);
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
