using Application.Contracts;
using Application.Validator;
using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace Application.Services
{
    public class HobbyService : IHobbyService
    {
        private readonly IHobbyRepository _hobbyRepository;

        public HobbyService(IHobbyRepository hobbyRepository)
        {
            _hobbyRepository = hobbyRepository;
        }

        public async Task<string> AddHobby(Hobby hobby)
        {
            HobbyValidator.Validate(hobby);
            return await _hobbyRepository.Add(hobby) ? "Success" : null;
        }

        public async Task<string> DeleteHobby(int id)
        {
            return await _hobbyRepository.Delete(id) ? "Success" : null;
        }

        public async Task<List<Hobby>> GetAllHobbies()
        {
            var a = await _hobbyRepository.GetAll();
            return a;
        }

        public async Task<Hobby> UpdateHobby(int id, JsonPatchDocument<Hobby> hobby)
        {
            return await _hobbyRepository.Update(id, hobby);
        }
    }
}
