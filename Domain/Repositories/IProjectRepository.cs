using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IProjectRepository
    {
        List<Project> GetAll();
        Task Add(Project project);
        Task Update(Project project);
        Project Delete(int id);
    }
}
