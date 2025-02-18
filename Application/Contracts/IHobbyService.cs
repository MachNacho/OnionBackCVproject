using Domain.Entities;

namespace Application.Contracts
{
    public interface IHobbyService
    {
        Task<List<Hobby>> GetAllHobbies();
        Task<Hobby> AddHobby(Hobby hobby);
        Task<Hobby> UpdateHobby(int id, Hobby hobby);
        Task<Hobby> DeleteHobby(int id);
    }
}
