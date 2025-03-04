using Domain.Entities;

namespace Domain.Contracts
{
    public interface IProjectTagRepository
    {
        Task<ProjectTags> Add(ProjectTags projectTags);
        Task<ProjectTags> Delete(int id);
        Task<ProjectTags> Update(int id, ProjectTags projectTags);
    }
}
