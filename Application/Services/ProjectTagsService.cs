using Application.Contracts;
using Domain.Contracts;
using Domain.Entities;

namespace Application.Services
{
    public class ProjectTagsService : IProjectTagInterface
    {
        private readonly IProjectTagRepository _projectTagRepository;
        public ProjectTagsService(IProjectTagRepository projectTagRepository)
        {
            _projectTagRepository = projectTagRepository;
        }
        public Task<ProjectTags> AddTagsToProject(ProjectTags projectTags)
        {
            return _projectTagRepository.Add(projectTags);
        }

        public Task<ProjectTags> RemoveTagsFromProject(int id)
        {
            return _projectTagRepository.Delete(id);
        }

        public Task<ProjectTags> UpdateTagsFromProject(int id, ProjectTags projectTags)
        {
            return _projectTagRepository.Update(id, projectTags);
        }
    }
}
