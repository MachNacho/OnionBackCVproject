using Domain.Contracts;
using Domain.Entities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    internal class ProjectTagRepository : IProjectTagRepository
    {
        private readonly ApplicationDbContext _context;
        public ProjectTagRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<> Add(ProjectTags projectTags)
        {
            return await _context.AddAsync(projectTags);
        }

        public Task Delete()
        {
            throw new NotImplementedException();
        }

        public Task Update()
        {
            throw new NotImplementedException();
        }
    }
}
