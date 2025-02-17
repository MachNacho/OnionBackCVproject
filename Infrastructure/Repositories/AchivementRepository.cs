using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class AchivementRepository : IAchivementRepository
    {
        private readonly ApplicationDbContext _context;
        public AchivementRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Achivement Add(Achivement achivement)
        {
            _context.Achivements.Add(achivement);
            _context.SaveChanges();
            return achivement;
        }

        public Achivement Delete(int id)
        {
            var a = _context.Achivements.Find(id);
            if (a == null) { return null; }
            _context.Achivements.Remove(a);
            _context.SaveChanges();
            return a;
        }

        public List<Achivement> GetAll()
        {
            return _context.Achivements.ToList();
        }

        public Achivement Update(int id, Achivement achivement)
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
