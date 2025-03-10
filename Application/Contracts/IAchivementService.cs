using Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace Application.Contracts
{
    public interface IAchivementService
    {
        Task<List<Achivement>> GetAllAchivements();
        Task<Achivement> AddAchivement(Achivement achivement);
        Task<Achivement> UpdateAchivement(int id, JsonPatchDocument<Achivement> ach);
        Task<bool> DeleteAchivement(int id);
    }
}
