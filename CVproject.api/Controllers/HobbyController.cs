using Application.Contracts;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
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
            try
            {
                var a = await _hobbyService.GetAllHobbies();
                return Ok(await _hobbyService.GetAllHobbies());
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
                var a = await _hobbyService.DeleteHobby(id);
                return Ok("Deleted");
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Hobby hobby)
        {
            if (!ModelState.IsValid) { return BadRequest(); }
            try
            {
                var a = await _hobbyService.AddHobby(hobby);
                return Created();
            }
            catch (ValidationException ex)
            {
                return NotFound(new { message = ex.Message });
            }

        }
        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> update([FromRoute] int id, [FromBody] JsonPatchDocument<Hobby> hobby)
        {
            try
            {
                if (hobby == null) { return BadRequest("Invalid patch document"); }
                var a = await _hobbyService.UpdateHobby(id, hobby);
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
