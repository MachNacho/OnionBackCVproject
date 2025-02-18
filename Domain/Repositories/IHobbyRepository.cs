using Domain.Entities;

namespace Domain.Repositories
{
    public interface IHobbyRepository
    {
        Task<List<Hobby>> GetAll();
        Task<Hobby> Add(Hobby hobby);
        Task<Hobby> Update(int id, Hobby hobby);
        Task<Hobby> Delete(int id);
    }
}
