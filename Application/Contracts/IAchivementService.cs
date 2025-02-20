using Domain.Entities;

namespace Application.Contracts
{
    public interface IAchivementService
    {
        Task<List<Achivement>> GetAllAchivements();
        Task<Achivement> AddAchivement(Achivement achivement);
        Task<Achivement> UpdateAchivement(int id, Achivement achivement);
        Task<Achivement> DeleteAchivement(int id);
    }
}
