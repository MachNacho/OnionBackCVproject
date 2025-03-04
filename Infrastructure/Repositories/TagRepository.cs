using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly ApplicationDbContext _context;
        public TagRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Tag> Add(Tag tag)
        {
            await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync();
            return tag;
        }


        public async Task<Tag> Delete(int id)
        {
            var a = await _context.Tags.FindAsync(id);
            if (a == null) { return null; }
            _context.Tags.Remove(a);
            await _context.SaveChangesAsync();
            return a;
        }

        public async Task<Tag> Update(int id, Tag tag)
        {
            var a = await _context.Tags.FindAsync(id);
            if (a == null) { return null; }
            a.TagName = tag.TagName;
            await _context.SaveChangesAsync();
            return a;
        }
    }
}
