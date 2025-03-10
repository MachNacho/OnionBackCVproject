using Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace Application.Contracts
{
    public interface IProjectService
    {
        Task<List<Project>> GetAllProjects();
        Task<Project> AddProject(Project project);
        Task<Project> UpdateProject(int id, JsonPatchDocument<Project> project);
        Task<bool> DeleteProject(int id);
    }
}
