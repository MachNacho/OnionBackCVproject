using Application.Contracts;
using Domain.Entities;

namespace Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectService(IProjectRepository projectRepository) { _projectRepository = projectRepository; }
        public Task<Project> AddProject(Project project)
        {
            return _projectRepository.Add(project);
        }

        public Task<Project> DeleteProject(int id)
        {
            return _projectRepository.Delete(id);
        }

        public Task<List<Project>> GetAllProjects()
        {
            return _projectRepository.GetAll();
        }

        public async Task<Project> UpdateProject(int id, Project project)
        {
            return await _projectRepository.Update(id, project);
        }
    }
}
