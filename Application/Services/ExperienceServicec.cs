using Application.Contracts;
using Domain.Entities;

namespace Application.Services
{
    public class ExperienceServicec : IExperienceService
    {
        private readonly IExperienceRepository _experienceRepository;
        public ExperienceServicec(IExperienceRepository _experienceRepository)
        {
            _experienceRepository = _experienceRepository;
        }
        public async Task<Experience> AddExperience(Experience experience)
        {
            return await _experienceRepository.Add(experience);
        }

        public async Task<Experience> DeleteExperience(int id)
        {
            return await _experienceRepository.Delete(id);
        }

        public async Task<List<Experience>> GetAllExperience()
        {
            return await _experienceRepository.GetAll();
        }

        public async Task<Experience> UpdateExperience(int id, Experience experience)
        {
            return await _experienceRepository.Update(id, experience);
        }
    }
}
