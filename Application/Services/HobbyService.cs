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

        public Hobby AddHobby(Hobby hobby)
        {
            return _hobbyRepository.Add(hobby);
        }

        public Hobby DeleteHobby(int id)
        {
            return _hobbyRepository.Delete(id);
        }

        public List<Hobby> GetAllHobbies()
        {
            return _hobbyRepository.GetAll();
        }

        public Hobby UpdateHobby(int id, Hobby hobby)
        {
            return _hobbyRepository.Update(id, hobby);
        }
    }
}
