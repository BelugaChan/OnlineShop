using api.Data;
using api.Dtos.Product;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class TagRepository : ITagRepository
    {
        private ApplicationDBContext context;
        private List<CreateProductRequestDro> createProductRequestDto = new List<CreateProductRequestDro>();
        public TagRepository(ApplicationDBContext context)
        {
            this.context = context;
        }

        public async Task<List<string>> GetProductTagNames(int productId)
        {
            return null;
            //return await context.Tags.Where(t =>t. == productId)
            //    .Select(e => e.Tag.Name).ToListAsync();
        }


        public async Task<List<Tag>> GetProductTags(int productId)
        {
            return null;
            //return await context.ProductsTags.Where(t => t.ProductId == productId)
            //    .Select(e => e.Tag).ToListAsync();
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
