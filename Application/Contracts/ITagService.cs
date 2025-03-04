
using Domain.Entities;

namespace Application.Contracts
{
    public interface ITagService
    {
        Task<Tag> AddTag(Tag tag);
        Task<Tag> UpdateTag(int id, Tag tag);
        Task<Tag> DeleteTag(int id);
    }
}
