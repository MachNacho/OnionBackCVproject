using Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace Application.Contracts
{
    public interface IExperienceService
    {
        Task<List<Experience>> GetAllExperience();
        Task<Experience> AddExperience(Experience experience);
        Task<Experience> UpdateExperience(int id, JsonPatchDocument<Experience> experience);
        Task<bool> DeleteExperience(int id);
    }
}
