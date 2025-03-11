using Application.Contracts;
using Application.DTO;
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

        public async Task<List<tagProjectDTO>> GetAllProjects()
        {
            var r = await _projectRepository.GetAll();

            return r.Select(x => new tagProjectDTO
            {
                ID = x.ID,
                Title = x.Title,
                Description = x.Description,
                ProjectDate = x.ProjectDate,
                Link = x.Link,
                HasPublicLink = x.HasPublicLink,
                Tags = x.Tags.Select(x => x.Tag.TagName).ToList()
            }).ToList();
        }

        public async Task<Project> UpdateProject(int id, JsonPatchDocument<Project> project)
        {
            return await _projectRepository.Update(id, project);
        }
    }
}
