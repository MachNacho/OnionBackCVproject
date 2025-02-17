using Domain.Entities;

namespace Domain.Repositories
{
    public interface ITagRepository
    {
        Task Add(Tag tag);
        Task Update(Tag tag);
        Tag Delete(int id);
    }
}
