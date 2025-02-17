using Domain.Entities;

namespace Domain.Repositories
{
    public interface IAchivementRepository
    {
        List<Achivement> GetAll();
        Achivement Add(Achivement achivement);
        Achivement Update(int id, Achivement achivement);
        Achivement Delete(int id);
    }
}
