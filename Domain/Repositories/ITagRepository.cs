using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ITagRepository
    {
        List<Tag> GetAll();
        Task Add(Tag tag);
        Task Update(Tag tag);
        Tag Delete(int id);
    }
}
