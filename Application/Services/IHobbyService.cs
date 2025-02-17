using Domain.Entities;

namespace Application.Services
{
    public interface IHobbyService
    {
        List<Hobby> GetAllHobbies();
        Task AddHobby(Hobby hobby);
        Task UpdateHobby(Hobby hobby);
        Hobby DeleteHobby(int id);
    }
}
