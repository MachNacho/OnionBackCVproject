using Domain.Entities;

namespace Application.Contracts
{
    public interface IProjectService
    {
        Task<List<Project>> GetAllProjects();
        Task<Project> AddProject(Project project);
        Task<Project> UpdateProject(int id, Project project);
        Task<Project> DeleteProject(int id);
    }
}
