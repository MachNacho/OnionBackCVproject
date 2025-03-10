using Domain.Entities;

namespace Domain.Contracts
{
    public interface ITagRepository
    {
        Task<Tag> Add(Tag tag);
        Task<Tag> Update(int id, Tag tag);
        Task<bool> Delete(int id);
    }
}
