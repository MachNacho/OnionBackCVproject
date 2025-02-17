using Domain.Entities;

namespace Application.Services
{
    internal interface IHobbyService
    {
        Task<List<Hobby>> GetAllHobbies();
        Task AddHobby(Hobby hobby);
        Task UpdateHobby(Hobby hobby);
        Task DeleteHobby(int id);
    }
}
