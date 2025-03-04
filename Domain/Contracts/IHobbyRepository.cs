using Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace Domain.Repositories
{
    public interface IHobbyRepository
    {
        Task<List<Hobby>> GetAll();
        Task<bool> Add(Hobby hobby);
        Task<Hobby> Update(int id, JsonPatchDocument<Hobby> hobby);//TODO fix update
        Task<bool> Delete(int id);
    }
}
