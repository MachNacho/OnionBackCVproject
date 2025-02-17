using Domain.Entities;

namespace Domain.Repositories
{
    public interface IHobbyRepository
    {
        List<Hobby> GetAll();
        Hobby Add(Hobby hobby);
        Hobby Update(int id, Hobby hobby);
        Hobby Delete(int id);
    }
}
