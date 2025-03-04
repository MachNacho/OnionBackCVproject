using Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace Application.Contracts
{
    public interface IHobbyService
    {
        Task<List<Hobby>> GetAllHobbies();
        Task<string> AddHobby(Hobby hobby);
        Task<Hobby> UpdateHobby(int id, JsonPatchDocument<Hobby> hobby);
        Task<string> DeleteHobby(int id);
    }
}
