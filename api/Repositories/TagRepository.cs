using api.Data;
using api.Dtos.Products;
using api.Interfaces.Repositories;
using api.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace api.Repositories
{
    public class TagRepository : ITagRepository
    {
        private ApplicationDBContext context;
        public TagRepository(ApplicationDBContext context)
        {
            this.context = context;
        }
       
        public async Task<Tag?> GetTag(int id)
        {
            var tag = await context.Tags.FirstOrDefaultAsync(t => t.Id == id);
            if (tag is null)
            {
                return null;
            }
            return tag;
        }

        public async Task<List<Tag>> GetTags()
        {
            return await context.Tags.ToListAsync();
        }
    }
}
