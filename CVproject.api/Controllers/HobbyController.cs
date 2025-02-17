using Application.Services;
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
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var a = _hobbyService.DeleteHobby(id);
            if (a == null) { return NotFound(); }
            return Ok("Deleted");
        }

    }
}
