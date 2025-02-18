using Application.Contracts;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services
{
    public class HobbyService : IHobbyService
    {
        private readonly IHobbyRepository _hobbyRepository;

        public HobbyService(IHobbyRepository hobbyRepository)
        {
            _hobbyRepository = hobbyRepository;
        }

        public async Task<Hobby> AddHobby(Hobby hobby)
        {
            return await _hobbyRepository.Add(hobby);
        }

        public async Task<Hobby> DeleteHobby(int id)
        {
            return await _hobbyRepository.Delete(id);
        }

        public async Task<List<Hobby>> GetAllHobbies()
        {
            return await _hobbyRepository.GetAll();
        }

        public async Task<Hobby> UpdateHobby(int id, Hobby hobby)
        {
            return await _hobbyRepository.Update(id, hobby);
        }
    }
}
