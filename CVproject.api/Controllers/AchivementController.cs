using Application.Contracts;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AchivementController : ControllerBase
    {
        private readonly IAchivementService _achivementService;
        public AchivementController(IAchivementService achivementService)
        {
            _achivementService = achivementService;
        }
        [HttpGet]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Client)]//Cache response
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var a = await _achivementService.GetAllAchivements();
                return Ok(await _achivementService.GetAllAchivements());
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
                var a = await _achivementService.DeleteAchivement(id);
                return Ok("Deleted");
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }

        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Achivement Ach)
        {
            if (!ModelState.IsValid) { return BadRequest(); }
            try
            {
                var a = await _achivementService.AddAchivement(Ach);
                return Created();
            }
            catch (ValidationException ex)
            {
                return NotFound(new { message = ex.Message });
            }

        }
        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> update([FromRoute] int id, [FromBody] JsonPatchDocument<Achivement> Ach)
        {
            try
            {
                if (Ach == null) { return BadRequest("Invalid patch document"); }
                var a = await _achivementService.UpdateAchivement(id, Ach);
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
