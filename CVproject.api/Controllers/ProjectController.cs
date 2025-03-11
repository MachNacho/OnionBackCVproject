using Application.Contracts;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        [HttpGet]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Client)]//Cache response
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _projectService.GetAllProjects());
            }
            catch (EmptyOrNoRecordsException)
            {
                return NoContent();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Project project)
        {
            if (!ModelState.IsValid) { return BadRequest(); }
            try
            {
                var a = await _projectService.AddProject(project);
                return Created();
            }
            catch (ValidationException ex)
            {
                return NotFound(new { message = ex.Message });
            }

        }
        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] JsonPatchDocument<Project> projec)
        {
            try
            {
                if (projec == null) { return BadRequest("Invalid patch document"); }
                var a = await _projectService.UpdateProject(id, projec);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (BusinessRuleViolationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var a = await _projectService.DeleteProject(id);
                return Ok("Deleted");
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
