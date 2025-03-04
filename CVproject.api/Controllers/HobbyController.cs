using Application.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CVproject.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HobbyController : ControllerBase
    {
        private readonly IHobbyService _hobbyService;

        public HobbyController(IHobbyService hobbyService)
        {
            _hobbyService = hobbyService;
        }

        [HttpGet]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Client)]//Cache response
        public async Task<IActionResult> GetAll()
        {
            var a = await _hobbyService.GetAllHobbies();
            if (a == null) { return NoContent(); }
            return Ok(await _hobbyService.GetAllHobbies());
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var a = await _hobbyService.DeleteHobby(id);
            if (a == null) { return NotFound(); }
            return Ok("Deleted");
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Hobby hobby)
        {
            var a = await _hobbyService.AddHobby(hobby);
            return Created();
        }
        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> update([FromRoute] int id, [FromBody] JsonPatchDocument<Hobby> hobby)
        {
            if (hobby == null) { return BadRequest("Invalid patch document"); }
            var a = await _hobbyService.UpdateHobby(id, hobby);
            if (a == null) { return NotFound(); }
            return Ok(a);
        }
    }
}
