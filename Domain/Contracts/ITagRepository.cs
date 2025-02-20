using Domain.Entities;

namespace Domain.Repositories
{
    public interface ITagRepository
    {
        Task<Tag> Add(Tag tag);
        Task<Tag> Update(int id,Tag tag);//TODO FIX UPDATE
        Task<Tag> Delete(int id);
    }
}
