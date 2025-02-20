using Application.Contracts;
using Domain.Entities;
using Domain.Repositories;

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
            return await _achivementRepository.Add(achivement);
        }

        public async Task<Achivement> DeleteAchivement(int id)
        {
            return await _achivementRepository.Delete(id);
        }

        public async Task<List<Achivement>> GetAllAchivements()
        {
            return await _achivementRepository.GetAll();
        }

        public async Task<Achivement> UpdateAchivement(int id, Achivement achivement)
        {
            return await _achivementRepository.Update(id, achivement);
        }
    }
}
