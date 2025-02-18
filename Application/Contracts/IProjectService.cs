using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Contracts
{
    public interface IProjectService
    {
        Task<List<Project>> GetAll();
        Task<Project> Add(Project project);
        Task<Project> Update(int id, Project project);
        Task<Project> Delete(int id);
    }
}
