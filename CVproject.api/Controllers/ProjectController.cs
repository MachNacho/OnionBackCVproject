using Application.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CVproject.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _projectService.GetAllProjects());
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Project project)
        {
            var a = await _projectService.AddProject(project);
            return Created();
        }
        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Project projec)
        {
            var a = await _projectService.UpdateProject(id, projec);
            if (a == null) { return NotFound(); }
            return Ok();
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var a = await _projectService.DeleteProject(id);
            if (a == null) { return NotFound(); }
            return Ok("Deleted");
        }
    }
}
