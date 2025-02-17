using Domain.Entities;

namespace Domain.Repositories
{
    public interface IHobbyRepository
    {
        List<Hobby> GetAll();
        Task Add(Hobby hobby);
        Task Update(Hobby hobby);
        Hobby Delete(int id);
    }
}
