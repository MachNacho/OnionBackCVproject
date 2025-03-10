using Application.Contracts;
using Application.Validator;
using Domain.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;

namespace Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectService(IProjectRepository projectRepository) { _projectRepository = projectRepository; }
        public Task<Project> AddProject(Project project)
        {
            ProjectValidator.Validate(project);
            return _projectRepository.Add(project);
        }

        public Task<bool> DeleteProject(int id)
        {
            return _projectRepository.Delete(id);
        }

        public Task<List<Project>> GetAllProjects()
        {
            return _projectRepository.GetAll();
        }

        public async Task<Project> UpdateProject(int id, JsonPatchDocument<Project> project)
        {
            return await _projectRepository.Update(id, project);
        }
    }
}
