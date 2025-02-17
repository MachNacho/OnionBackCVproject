using Domain.Entities;

namespace Domain.Repositories
{
    public interface IAchivementRepository
    {
        List<Achivement> GetAll();
        Task Add(Achivement achivement);
        Task Update(Achivement achivement);
        Achivement Delete(int id);
    }
}
