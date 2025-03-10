using Domain.Contracts;
using Domain.Entities;
using Infrastructure.Data;
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
            await _context.educations.AddAsync(education);
            await _context.SaveChangesAsync();
            return education;
        }

        public async Task<bool> Delete(int id)
        {
            var a = await _context.educations.FindAsync(id);
            _context.educations.Remove(a);
            await _context.SaveChangesAsync();
            return a;
        }

        public async Task<List<Education>> GetAll()
        {
            var a = _context.educations.AsQueryable();
            return await a.ToListAsync();
        }

        public async Task<Education> Update(int id, Education education)
        {
            var a = await _context.educations.FindAsync(id);
            if (a == null) { return null; }
            a.Title = education.Title;
            a.EducationLevel = education.EducationLevel;
            a.Institution = education.Institution;
            a.StartDate = education.StartDate;
            a.EndDate = education.EndDate;
            a.Description = education.Description;
            a.ImageSrc = education.ImageSrc;
            await _context.SaveChangesAsync();
            return a;
        }
    }
}
