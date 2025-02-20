using Domain.Entities;

namespace Application.Contracts
{
    public interface IEducationService
    {
        Task<List<Education>> GetAllEducation();
        Task<Education> AddEducation(Education education);
        Task<Education> UpdateEducation(int id, Education education);
        Task<Education> DeleteEducation(int id);
    }
}
