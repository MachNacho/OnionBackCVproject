using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IProjectTagRepository
    {
        Task Add(ProjectTags projectTags);
        Task Delete(int id);
        Task Update(int id,ProjectTags projectTags);
    }
}
