using Application.Contracts;
using Application.Validator;
using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace Application.Services
{
    public class AchivementService : IAchivementService
    {
        private readonly IAchivementRepository _achivementRepository;
        public AchivementService(IAchivementRepository achivementRepository)
        {
            _achivementRepository = achivementRepository;
        }
        public async Task<Achivement> AddAchivement(Achivement achivement)
        {
            AchievementValidator.Validate(achivement);
            return await _achivementRepository.Add(achivement);
        }

        public async Task<bool> DeleteAchivement(int id)
        {
            return await _achivementRepository.Delete(id);
        }

        public async Task<List<Achivement>> GetAllAchivements()
        {
            return await _achivementRepository.GetAll();
        }

        public async Task<Achivement> UpdateAchivement(int id, JsonPatchDocument<Achivement> ach)
        {
            return await _achivementRepository.Update(id, ach);
        }
    }
}
