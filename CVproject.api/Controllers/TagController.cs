using Application.Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CVproject.api.Controllers
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
        public async Task<IActionResult> DeleteTag(int id)
        {
            await _tagService.DeleteTag(id);
            return Ok("Deleted");
        }
        [HttpPost]
        public async Task<IActionResult> AddTag(Tag tag)
        {
            await _tagService.AddTag(tag);
            return Created();
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateTag(int id, Tag tag)
        {
            var a = await _tagService.UpdateTag(id, tag);
            if (a == null) { return NotFound(); }
            return Ok(a);
        }
    }
}
