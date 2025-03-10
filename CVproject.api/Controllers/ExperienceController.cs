using Application.Contracts;
using Domain.Entities;
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
            return Ok(await _experienceService.GetAllExperience());
        }
        [HttpPost]
        public async Task<IActionResult> AddExperience(Experience experience)
        {
            await _experienceService.AddExperience(experience);
            return Created();
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateExperience(int id, Experience experience)
        {
            var result = await _experienceService.UpdateExperience(id, experience);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteExperience(int id)
        {
            var result = await _experienceService.DeleteExperience(id);
            if (result == null) { return NotFound(); }
            return Ok(result);
        }
    }
}
