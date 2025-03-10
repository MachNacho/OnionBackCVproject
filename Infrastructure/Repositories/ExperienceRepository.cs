using Domain.Contracts;
using Domain.Entities;
using Domain.Exceptions;
using Infrastructure.Data;
using Microsoft.AspNetCore.JsonPatch;
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
            try
            {
                await _context.experiences.AddAsync(experience);
                await _context.SaveChangesAsync();
                return experience;
            }
            catch (Exception)
            {
                throw new BusinessRuleViolationException($"Value {experience} can't be added");
            }

        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var a = await _context.experiences.FindAsync(id);
                _context.experiences.Remove(a);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception) 
            {
                throw new NotFoundException($"The ID: {id} isn't found in the records");
            }

        }

        public async Task<List<Experience>> GetAll()
        {
                var r = await _context.experiences.AsNoTracking().ToListAsync(); // Prevents EF from tracking objects in memeory
                return r.Count == 0 ? throw new EmptyOrNoRecordsException("No hobby exists") : r;
        }

        public async Task<Experience> Update(int id, JsonPatchDocument<Experience> experience)
        {
            try
            {
                var a = await _context.experiences.FindAsync(id);
                if (a == null) { throw new NotFoundException($"The ID: {id} isn't found in the records"); }
                experience.ApplyTo(a);
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
