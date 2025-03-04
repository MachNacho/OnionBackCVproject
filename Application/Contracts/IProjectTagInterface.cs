using Domain.Entities;

namespace Application.Contracts
{
    public interface IProjectTagInterface
    {
        public Task<ProjectTags> AddTagsToProject(ProjectTags projectTags);
        public Task<ProjectTags> RemoveTagsFromProject(int id);
        public Task<ProjectTags> UpdateTagsFromProject(int id, ProjectTags projectTags);
    }
}
