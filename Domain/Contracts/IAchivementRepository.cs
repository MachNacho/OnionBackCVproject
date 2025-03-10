using Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace Domain.Contracts
{
    public interface IAchivementRepository
    {
        Task<List<Achivement>> GetAll();
        Task<Achivement> Add(Achivement achivement);
        Task<Achivement> Update(int id, JsonPatchDocument<Achivement> ach);
        Task<bool> Delete(int id);
    }
}
