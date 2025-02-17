using Domain.Entities;

namespace Application.Services
{
    public interface IHobbyService
    {
        List<Hobby> GetAllHobbies();
        Hobby AddHobby(Hobby hobby);
        Hobby UpdateHobby(int id, Hobby hobby);
        Hobby DeleteHobby(int id);
    }
}
