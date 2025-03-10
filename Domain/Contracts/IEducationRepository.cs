using Domain.Entities;

namespace Domain.Contracts
{
    public interface IEducationRepository
    {
        Task<List<Education>> GetAll();
        Task<Education> Add(Education education);
        Task<Education> Update(int id, Education education);//TODO FIX UPDATE
        Task<bool> Delete(int id);
    }
}
