using Domain.Entities;

namespace Application.Contracts
{
    public interface IExperienceService
    {
        Task<List<Experience>> GetAllExperience();
        Task<Experience> AddExperience(Experience experience);
        Task<Experience> UpdateExperience(int id, Experience experience);
        Task<Experience> DeleteExperience(int id);
    }
}
