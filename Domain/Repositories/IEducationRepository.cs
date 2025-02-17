using Domain.Entities;

namespace Domain.Repositories
{
    public interface IEducationRepository
    {
        List<Education> GetAll();
        Task Add(Education education);
        Task Update(Education education);
        Education Delete(int id);
    }
}
