using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectService(IProjectRepository projectRepository) { _projectRepository = projectRepository; }
        public Task<Project> Add(Project project)
        {
            throw new NotImplementedException();
        }

        public Task<Project> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Project>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Project> Update(int id,Project project)
        {
            return await _projectRepository.Update(id, project);
        }
    }
}
