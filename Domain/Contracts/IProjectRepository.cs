using Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace Domain.Contracts
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAll();
        Task<Project> Add(Project project);
        Task<Project> Update(int id, JsonPatchDocument<Project> project);//TODO FIX UPDATE
        Task<bool> Delete(int id);
    }
}
