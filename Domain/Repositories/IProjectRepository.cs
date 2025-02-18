using Domain.Entities;

namespace Domain.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAll();
        Task<Project> Add(Project project);
        Task<Project> Update(int id,Project project);
        Task<Project> Delete(int id);
    }
}
