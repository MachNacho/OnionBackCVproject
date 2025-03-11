using Domain.Contracts;
using Domain.Entities;
using Domain.Exceptions;
using Infrastructure.Data;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class EducationRepository : IEducationRepository
    {
        private readonly ApplicationDbContext _context;
        public EducationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Education> Add(Education education)
        {
            try
            {
                await _context.educations.AddAsync(education);
                await _context.SaveChangesAsync();
                return education;
            }
            catch (Exception)
            {
                throw new BusinessRuleViolationException($"Value {education.Title} can't be added");
            }

        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var a = await _context.educations.FindAsync(id);
                _context.educations.Remove(a);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw new NotFoundException($"The ID: {id} isn't found in the records");
            }
;
        }
        public async Task<List<Education>> GetAll()
        {
            var r = await _context.educations.AsNoTracking().ToListAsync(); // Prevents EF from tracking objects in memeory
            return r.Count == 0 ? throw new EmptyOrNoRecordsException("No hobby exists") : r;
        }
        public async Task<Education> Update(int id, JsonPatchDocument<Education> education)
        {
            try
            {
                var a = await _context.educations.FindAsync(id);
                if (a == null) { throw new NotFoundException($"The ID: {id} isn't found in the records"); }
                education.ApplyTo(a);
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
