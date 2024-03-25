using api.Data;
using api.Dtos.Lustre;
using api.Helpers;
using api.Interfaces;
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
            var lustres = context.Lustres.AsQueryable();
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
            return await context.Lustres.FindAsync(id);
        }

        public async Task<Lustre> CreateItemAsync(Lustre lustre)
        {
            await context.Lustres.AddAsync(lustre);
            await context.SaveChangesAsync();
            return lustre;
        }

        public async Task<Lustre?> DeleteItemAsync(int id)
        {
            var lustre = await context.Lustres.FirstOrDefaultAsync(t => t.Id == id);
            if (lustre == null)
            {
                return null;
            }
            context.Lustres.Remove(lustre);
            await context.SaveChangesAsync();
            return lustre;
        }

        public async Task<Lustre?> UpdateItemAsync(int id, UpdateLustreRequestDto lustreDto)
        {
            var lustre = await context.Lustres.FirstOrDefaultAsync(t => t.Id == id);
            if (lustre == null)
            {
                return null;
            }
            lustre.Name = lustreDto.Name;
            lustre.Description = lustreDto.Description;
            lustre.PicLink = lustreDto.PicLink;
            lustre.Cost = lustreDto.Cost;
            lustre.Company = lustreDto.Company;
            lustre.BulbCount = lustreDto.BulbCount;
            lustre.Weight = lustreDto.Weight;

            context.Lustres.Update(lustre);
            await context.SaveChangesAsync();
            return lustre;
        }
    }
}
