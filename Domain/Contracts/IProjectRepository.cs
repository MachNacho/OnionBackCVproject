using Domain.Entities;

namespace Domain.Contracts
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAll();
        Task<Project> Add(Project project);
        Task<Project> Update(int id, Project project);//TODO FIX UPDATE
        Task<Project> Delete(int id);
    }
}
