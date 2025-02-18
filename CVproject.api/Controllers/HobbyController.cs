using Application.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _hobbyService.GetAllHobbies());
        }
        [Authorize]
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
        public async  Task<IActionResult> update([FromRoute] int id, [FromBody] Hobby hobby)
        {
            var a = await _hobbyService.UpdateHobby(id, hobby);
            if (a == null) { return NotFound(); }
            return Ok(a);
        }
    }
}
