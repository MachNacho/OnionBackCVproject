
using Domain.Entities;

namespace Application.Contracts
{
    public interface ITagService
    {
        Task<Tag> AddTag(Tag tag);
        Task<Tag> UpdateTag(int id, Tag tag);
        Task<bool> DeleteTag(int id);
    }
}
