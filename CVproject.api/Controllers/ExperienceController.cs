using Application.Contracts;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        private readonly IExperienceService _experienceService;
        public ExperienceController(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllExperience()
        {
            try
            {
                return Ok(await _experienceService.GetAllExperience());
            }
            catch (EmptyOrNoRecordsException)
            {
                return NoContent();
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddExperience(Experience experience)
        {
            if (!ModelState.IsValid) { return BadRequest("Invalid object"); }
            try
            {
                await _experienceService.AddExperience(experience);
                return Created();
            }
            catch (ValidationException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateExperience(int id, JsonPatchDocument<Experience> experience)
        {
            try
            {
                if (experience == null) { return BadRequest("Invalid patch document"); }
                var result = await _experienceService.UpdateExperience(id, experience);
                return Ok(result);
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
        public async Task<IActionResult> DeleteExperience(int id)
        {
            try
            {
                var result = await _experienceService.DeleteExperience(id);
                return Ok("Deleted");
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
