using Domain.Entities;

namespace Domain.Repositories
{
    public interface IProjectRepository
    {
        List<Project> GetAll();
        Task Add(Project project);
        Task Update(Project project);
        Project Delete(int id);
    }
}
