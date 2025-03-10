using Application.Contracts;
using Application.Services;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.JsonPatch;
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
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Client)]//Cache response
        public async Task<IActionResult> GettAll()
        {
            try
            {
                var a = await _educationService.GetAllEducation();
                return Ok(a);
            }
            catch (EmptyOrNoRecordsException)
            {
                return NoContent();
            }
           
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var a = await _educationService.DeleteEducation(id);
                return Ok("Deleted");
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
           
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Education EDU)
        {
            if (!ModelState.IsValid) { return BadRequest(); }
            try
            {
                var a = await _educationService.AddEducation(EDU);
                return Created();
            }
            catch (ValidationException ex)
            {
                return NotFound(new { message = ex.Message });
            }

        }
        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> update([FromRoute] int id, [FromBody] JsonPatchDocument<Education> EDU)
        {
            try
            {
                if (EDU == null) { return BadRequest("Invalid patch document"); }
                var a = await _educationService.UpdateEducation(id, EDU);
                return Ok(a);
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
    }
}
