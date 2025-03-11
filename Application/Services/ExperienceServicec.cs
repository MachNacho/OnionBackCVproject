using Application.Contracts;
using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace Application.Services
{
    public class ExperienceServicec : IExperienceService
    {
        private readonly IExperienceRepository _experienceRepository;
        public ExperienceServicec(IExperienceRepository experienceRepository)
        {
            _experienceRepository = experienceRepository;
        }
        public async Task<Experience> AddExperience(Experience experience)
        {
            return await _experienceRepository.Add(experience);
        }

        public async Task<bool> DeleteExperience(int id)
        {
            return await _experienceRepository.Delete(id);
        }

        public async Task<List<Experience>> GetAllExperience()
        {
            return await _experienceRepository.GetAll();
        }
        public async Task<Experience> UpdateExperience(int id, JsonPatchDocument<Experience> experience)
        {
            return await _experienceRepository.Update(id, experience);
        }
    }
}
