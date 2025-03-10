using Domain.Entities;

namespace Domain.Contracts
{
    public interface ITagRepository
    {
        Task<Tag> Add(Tag tag);
        Task<Tag> Update(int id, Tag tag);//TODO FIX UPDATE
        Task<Tag> Delete(int id);
    }
}
