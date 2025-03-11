using Application.Contracts;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;
        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteTag([FromRoute] int id)
        {
            try
            {
                await _tagService.DeleteTag(id);
                return Ok("Deleted");
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }

        }
        [HttpPost]
        public async Task<IActionResult> AddTag(Tag tag)
        {
            if (!ModelState.IsValid) { return BadRequest(); }
            try
            {
                await _tagService.AddTag(tag);
                return Created();
            }
            catch (BusinessRuleViolationException ex)
            {
                return NotFound(new { message = ex.Message });
            }

        }
        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> UpdateTag([FromRoute] int id, [FromBody] Tag tag)
        {
            try
            {
                var a = await _tagService.UpdateTag(id, tag);
                return Ok(a);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (BusinessRuleViolationException ex)
            {
                return NotFound(new { message = ex.Message });
            }

        }
    }
}
