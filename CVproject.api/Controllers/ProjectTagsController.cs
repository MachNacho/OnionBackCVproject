using Application.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTagsController : ControllerBase
    {
        private readonly IProjectTagInterface _projectTagInterface;
        public ProjectTagsController(IProjectTagInterface projectTagInterface)
        {
            _projectTagInterface = projectTagInterface;
        }
        [HttpPost]
        public async Task<IActionResult> AddTagsToProject(ProjectTags projectTags)
        {
            return Ok(await _projectTagInterface.AddTagsToProject(projectTags));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveTagsFromProject(int id)
        {
            var result = await _projectTagInterface.RemoveTagsFromProject(id);
            if (result == null) { return NotFound(); }
            return Ok("Deleted");
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateTagsFromProject(int id, ProjectTags projectTags)
        {
            var result = await _projectTagInterface.UpdateTagsFromProject(id, projectTags);
            if (result == null) { return NotFound(); }
            return Created();
        }
    }
}
