using Domain.Entities;

namespace Domain.Contracts
{
    public interface IExperienceRepository
    {
        Task<List<Experience>> GetAll();
        Task<Experience> Add(Experience experience);
        Task<Experience> Update(int id, Experience experience);//TODO FIX UPDATE
        Task<Experience> Delete(int id);
    }
}
