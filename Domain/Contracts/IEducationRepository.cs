using Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace Domain.Contracts
{
    public interface IEducationRepository
    {
        Task<List<Education>> GetAll();
        Task<Education> Add(Education education);
        Task<Education> Update(int id, JsonPatchDocument<Education> education);
        Task<bool> Delete(int id);
    }
}
