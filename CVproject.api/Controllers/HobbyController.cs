using Application.Services;
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
        public IActionResult GetAll()
        {
            return Ok(_hobbyService.GetAllHobbies());
        }
        [Authorize]
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var a = _hobbyService.DeleteHobby(id);
            if (a == null) { return NotFound(); }
            return Ok("Deleted");
        }
        [HttpPost]
        public IActionResult Add([FromBody] Hobby hobby)
        {
            var a = _hobbyService.AddHobby(hobby);
            return Created();
        }
        [HttpPatch]
        [Route("{id}")]
        public IActionResult update([FromRoute] int id, [FromBody] Hobby hobby)
        {
            var a = _hobbyService.UpdateHobby(id, hobby);
            if (a == null) { return NotFound(); }
            return Ok(a);
        }
    }
}
