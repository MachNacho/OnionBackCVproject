using Application.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly IEducationService _educationService;
        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;
        }
        [HttpGet]
        public async Task<IActionResult> GettAll()
        {
            return Ok(await _educationService.GetAllEducation());
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var a = await _educationService.DeleteEducation(id);
            if (a == null) { return NotFound(); }
            return Ok("Deleted");
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Education EDU)
        {
            var a = await _educationService.AddEducation(EDU);
            return Created();
        }
        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> update([FromRoute] int id, [FromBody] Education EDU)
        {
            var a = await _educationService.UpdateEducation(id, EDU);
            if (a == null) { return NotFound(); }
            return Ok(a);
        }
    }
}
