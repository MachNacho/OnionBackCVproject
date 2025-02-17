using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class HobbyRepository : IHobbyRepository
    {
        private readonly ApplicationDbContext _context;
        public HobbyRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Hobby Add(Hobby hobby)
        {
            _context.Hobby.Add(hobby);
            _context.SaveChanges();
            return hobby;
        }

        public Hobby Delete(int id)
        {
            var a = _context.Hobby.Find(id);
            if (a == null) { return null; }
            _context.Hobby.Remove(a);
            _context.SaveChanges();
            return a;
        }

        public List<Hobby> GetAll()
        {
            return _context.Hobby.ToList();
        }

        public Hobby Update(int id, Hobby hobby)
        {
            var a = _context.Hobby.Find(id);
            if (a == null) { return null; }
            a.Title = hobby.Title;
            a.Description = hobby.Description;
            a.ImageSrc = hobby.ImageSrc;
            _context.SaveChanges();
            return a;
        }
    }
}
