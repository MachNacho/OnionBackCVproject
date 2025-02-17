using Domain.Entities;

namespace Domain.Repositories
{
    public interface IExperienceRepository
    {
        List<Experience> GetAll();
        Task Add(Experience experience);
        Task Update(Experience experience);
        Experience Delete(int id);
    }
}
