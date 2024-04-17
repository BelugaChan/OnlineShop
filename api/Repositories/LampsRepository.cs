using api.Data;
using api.Dtos.Lamp;
using api.Helpers;
using api.Interfaces;
using api.Mappers.Lamps;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class LampsRepository : ILampsRepository
    {
        private readonly ApplicationDBContext context;
        public LampsRepository(ApplicationDBContext context)
        {
            this.context = context;
        }

        public async Task<Lamp> CreateLampAsync(CreateLampRequestDto lampRequestDto)
        {
            var lamp = lampRequestDto.ToLampFromCreateDto();
            foreach (var item in lampRequestDto.TagIds)
            {
                var tag = await context.Tags.FirstOrDefaultAsync(t => t.Id == item);
                if (tag is not null) lamp.Tags.Add(tag);
            }
            await context.Lamps.AddAsync(lamp);
            await context.SaveChangesAsync();
            return lamp;
        }

        public async Task<Lamp?> DeleteLampAsync(int id)
        {
            var lamp = await context.Lamps.FirstOrDefaultAsync(t => t.Id == id);
            if (lamp == null)
            {
                return null;
            }
            context.Lamps.Remove(lamp);
            await context.SaveChangesAsync();
            return lamp;
        }

        public async Task<List<Lamp>> GetAllAsync(QueryObject queryObject)
        {
            var lamps = context.Lamps.Include(t => t.Tags).AsQueryable();
            if (!string.IsNullOrWhiteSpace(queryObject.ItemName))
            {
                lamps = lamps.Where(t => t.Name.Contains(queryObject.ItemName));
            }
            if (!string.IsNullOrWhiteSpace(queryObject.SortBy))
            {
                if (queryObject.SortBy.ToLower().Equals("cost"))
                {
                    lamps = queryObject.IsDescending ? lamps.OrderByDescending(t => t.Cost) 
                    : lamps.OrderBy(t => t.Cost);
                }
            }
            return await lamps.ToListAsync();
        }

        public async Task<Lamp?> GetLampByIdAsync(int id)
        {
            var lamp = await context.Lamps.Include(t => t.Tags).FirstOrDefaultAsync(t => t.Id == id);
            if (lamp is null)
            {
                return null;
            }
            return lamp;
        }

        public async Task<Lamp?> UpdateLampAsync(int id, UpdateLampRequestDto lampRequestDto)
        {
            var lamp = await context.Lamps.Include(t => t.Tags).FirstOrDefaultAsync(t => t.Id == id);
            if (lamp is null)
            {
                return null;
            }

            foreach (var item in lampRequestDto.TagIds)
            {
                var tag = await context.Tags.FirstOrDefaultAsync(x => x.Id == item);
                if (tag is not null)
                    lamp.Tags.Add(tag);
            }
            lamp = lampRequestDto.ToLampFromUpdateDto(lamp);

            context.Lamps.Update(lamp);
            await context.SaveChangesAsync();
            return lamp;
        }
    }
}