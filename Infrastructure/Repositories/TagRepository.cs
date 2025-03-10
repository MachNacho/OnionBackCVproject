using Domain.Contracts;
using Domain.Entities;
using Domain.Exceptions;
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
            try
            {
                await _context.Tags.AddAsync(tag);
                await _context.SaveChangesAsync();
                return tag;
            }
            catch(Exception)
            {
                throw new BusinessRuleViolationException($"Value {tag.TagName} can't be added");
            }

        }


        public async Task<bool> Delete(int id)
        {
            try
            {
                var a = await _context.Tags.FindAsync(id);
                _context.Tags.Remove(a);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw new NotFoundException($"The ID: {id} isn't found in the records");
            }

        }

        public async Task<Tag> Update(int id, Tag tag)
        {
            try
            {
                var a = await _context.Tags.FindAsync(id);
                if (a == null) { throw new NotFoundException($"The ID: {id} isn't found in the records"); }
                a.TagName = tag.TagName;
                await _context.SaveChangesAsync();
                return a;
            }
            catch (Exception)
            {
                throw new BusinessRuleViolationException($"Value can't be updated");
            }

        }
    }
}
