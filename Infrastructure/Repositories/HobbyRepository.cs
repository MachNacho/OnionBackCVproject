using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class HobbyRepository : IHobbyRepository
    {
        private readonly ApplicationDbContext _context;
        public HobbyRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task Add(Hobby hobby)
        {
            throw new NotImplementedException();
        }

        public Hobby Delete(int id)
        {
            var a = _context.Hobby.Find(id);
            if (a == null) { return null ; }
            _context.Hobby.Remove(a);   
            _context.SaveChanges();
            return a;
        }

        public List<Hobby> GetAll()
        {
            return _context.Hobby.ToList();
        }

        public Task Update(Hobby hobby)
        {
            throw new NotImplementedException();
        }
    }
}
