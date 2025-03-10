using Application.Contracts;
using Application.Validator;
using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace Application.Services
{
    public class EducationService : IEducationService
    {
        private readonly IEducationRepository _educationRepository;
        public EducationService(IEducationRepository educationRepository) { _educationRepository = educationRepository; }

        public async Task<Education> AddEducation(Education education)
        {
            EducationValidator.Validate(education);
            return await _educationRepository.Add(education);
        }

        public async Task<bool> DeleteEducation(int id)
        {
            return await _educationRepository.Delete(id);
        }

        public async Task<List<Education>> GetAllEducation()
        {
            return await _educationRepository.GetAll();
        }

        public async Task<Education> UpdateEducation(int id, JsonPatchDocument<Education> education)
        {
            return await _educationRepository.Update(id, education);
        }
    }
}
