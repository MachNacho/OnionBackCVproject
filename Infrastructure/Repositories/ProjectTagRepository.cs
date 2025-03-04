using Domain.Contracts;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class ProjectTagRepository : IProjectTagRepository
    {
        private readonly ApplicationDbContext _context;
        public ProjectTagRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ProjectTags> Add(ProjectTags projectTags)
        {
            await _context.AddAsync(projectTags);
            await _context.SaveChangesAsync();
            return projectTags;
        }

        public Task<ProjectTags> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ProjectTags> Update(int id, ProjectTags projectTags)
        {
            var a = await _context.ProjectTags.FindAsync(id);
            if (projectTags == null)
            {
                return null;
            }
            a.ProjectID = projectTags.ProjectID;
            a.TagID = projectTags.TagID;
            await _context.SaveChangesAsync();
            return a;
        }
    }
}
