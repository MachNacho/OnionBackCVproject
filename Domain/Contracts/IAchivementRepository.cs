using Domain.Entities;

namespace Domain.Repositories
{
    public interface IAchivementRepository
    {
        Task<List<Achivement>> GetAll();
        Task<Achivement> Add(Achivement achivement);
        Task<Achivement> Update(int id, Achivement achivement);
        Task<Achivement> Delete(int id);//TODO FIX UPDATE
    }
}
