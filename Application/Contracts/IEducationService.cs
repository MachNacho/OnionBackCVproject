using Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace Application.Contracts
{
    public interface IEducationService
    {
        Task<List<Education>> GetAllEducation();
        Task<Education> AddEducation(Education education);
        Task<Education> UpdateEducation(int id, JsonPatchDocument<Education> education);
        Task<bool> DeleteEducation(int id);
    }
}
