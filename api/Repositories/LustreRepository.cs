using api.Data;
using api.Dtos.Lustre;
using api.Helpers;
using api.Interfaces;
using api.Mappers.Lustres;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class LustreRepository : ILustreRepository
    {
        private readonly ApplicationDBContext context;
        public LustreRepository(ApplicationDBContext context)
        {
            this.context = context;
        }       

        public async Task<List<Lustre>> GetAllAsync(QueryObject queryObject)
        {
            var lustres = context.Lustres.Include(t => t.Tags).AsQueryable();
            if (!string.IsNullOrWhiteSpace(queryObject.ItemName))
            {
                lustres = lustres.Where(t => t.Name.Contains(queryObject.ItemName));
            }
            if (!string.IsNullOrWhiteSpace(queryObject.SortBy))
            {
                if (queryObject.SortBy.ToLower().Equals("cost"))
                {
                    lustres = queryObject.IsDescending ? lustres.OrderByDescending(t => t.Cost)
                    : lustres.OrderBy(t => t.Cost);
                }
            }
            return await lustres.ToListAsync();
        }

        public async Task<Lustre?> GetItemByIdAsync(int id)
        {
            var lustre = await context.Lustres.Include(t => t.Tags).FirstOrDefaultAsync(x => x.Id == id);
            if (lustre is null) return null;
            return lustre;
        }

        public async Task<Lustre> CreateItemAsync(CreateLustreRequestDto lustreRequestDto)
        {
            var lustre = lustreRequestDto.ToLustreFromCreateDto();
            foreach (var item in lustreRequestDto.TagIds)
            {
                var tag = await context.Tags.FirstOrDefaultAsync(t => t.Id == item);
                if (tag is not null) lustre.Tags.Add(tag);
            }
            await context.Lustres.AddAsync(lustre);
            await context.SaveChangesAsync();
            return lustre;
        }

        public async Task<Lustre?> DeleteItemAsync(int id)
        {
            var lustre = await context.Lustres.FirstOrDefaultAsync(t => t.Id == id);
            if (lustre is null) return null;

            context.Lustres.Remove(lustre);
            await context.SaveChangesAsync();
            return lustre;
        }

        public async Task<Lustre?> UpdateItemAsync(int id, UpdateLustreRequestDto lustrerequestDto)
        {
            var lustre = await context.Lustres.Include(t => t.Tags).FirstOrDefaultAsync(t => t.Id == id);
            if (lustre is null) return null;

            foreach (var item in lustrerequestDto.TagIds)
            {
                var tag = await context.Tags.FirstOrDefaultAsync(x => x.Id == item);
                if (tag is not null)
                    lustre.Tags.Add(tag);
            }
            lustre = lustrerequestDto.ToLustreFromUpdateDto(lustre);

            context.Lustres.Update(lustre);
            await context.SaveChangesAsync();
            return lustre;
        }
    }
}
