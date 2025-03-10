using Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace Domain.Contracts
{
    public interface IExperienceRepository
    {
        Task<List<Experience>> GetAll();
        Task<Experience> Add(Experience experience);
        Task<Experience> Update(int id, JsonPatchDocument<Experience> experience);
        Task<bool> Delete(int id);
    }
}
