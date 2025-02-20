using Application.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CVproject.api.Controllers
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
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _achivementService.GetAllAchivements());
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var a = await _achivementService.DeleteAchivement(id);
            if (a == null) { return NotFound(); }
            return Ok("Deleted");
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Achivement Ach)
        {
            var a = await _achivementService.AddAchivement(Ach);
            return Created();
        }
        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> update([FromRoute] int id, [FromBody] Achivement Ach)
        {
            var a = await _achivementService.UpdateAchivement(id, Ach);
            if (a == null) { return NotFound(); }
            return Ok(a);
        }
    }
}
