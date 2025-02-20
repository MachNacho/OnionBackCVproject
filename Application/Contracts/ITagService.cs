
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface ITagService
    {
        Task<Tag> AddTag(Tag tag);
        Task<Tag> UpdateTag(int id, Tag tag);
        Task<Tag> DeleteTag(int id);
    }
}
