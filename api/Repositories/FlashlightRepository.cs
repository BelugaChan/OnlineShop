using api.Data;
using api.Dtos.Flashlights;
using api.Helpers;
using api.Interfaces.Repositories;
using api.Mappers.Flashlights;
using api.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace api.Repositories
{
    public class FlashlightRepository : IFlashlightRepository
    {
        private readonly ApplicationDBContext context;
        public FlashlightRepository(ApplicationDBContext context)
        {
            this.context = context;
        }

        public async Task<List<Tag>> GetFlashlightsTags()
        {
            var flashlightTags = await context.Flashlights.Select(t => t.Tags).ToListAsync();
            var res = new List<Tag>();
            foreach (var item in flashlightTags)
            {
                foreach (var value in item)
                {
                    res.Add(value);
                }                
            }
            return res.Select(t => t).Distinct().ToList();
        }

        public async Task<Flashlight> CreateFlashlightAsync(CreateFlashlightRequestDto flashlightRequestDto)
        {
            var flashlight = flashlightRequestDto.ToFlashlightFromCreateDto();
            foreach (var item in flashlightRequestDto.TagIds)
            {
                var tag = await context.Tags.FirstOrDefaultAsync(t => t.Id == item);
                if(tag is not null) flashlight.Tags.Add(tag);
            }
            await context.Flashlights.AddAsync(flashlight);
            await context.SaveChangesAsync();
            return flashlight;
        }

        public async Task<Flashlight?> GetFlashlightByIdAsync(int id)
        {
            var flashlight = await context.Flashlights.Include(t => t.Tags).FirstOrDefaultAsync(x => x.Id == id);
            if (flashlight is null)
            {
                return null;
            }
            return flashlight;
        }

        public async Task<List<Flashlight>> GetFlashlightsAsync(/*QueryObject queryObject*/)
        {
            var flashlgihts = context.Flashlights.Include(t => t.Tags).AsQueryable();

            //if (!string.IsNullOrWhiteSpace(queryObject.ItemName))
            //{
            //    flashlgihts = flashlgihts.Where(t => t.Name.Contains(queryObject.ItemName));
            //}

            //if (!string.IsNullOrWhiteSpace(queryObject.SortBy))
            //{
            //    if (queryObject.SortBy.ToLower().Equals("cost"))
            //    {
            //        flashlgihts = queryObject.IsDescending ? flashlgihts.OrderByDescending(t => t.Cost) 
            //        : flashlgihts.OrderBy(t => t.Cost);
            //    }
            //}
            return await flashlgihts.ToListAsync();
        }

        public async Task<Flashlight?> RemoveFlashlight(int id)
        {
            var flashlight = await context.Flashlights.Include(t => t.Tags).FirstOrDefaultAsync(t => t.Id == id);
            if (flashlight is null)
            {
                return null;
            }
            context.Flashlights.Remove(flashlight);
            await context.SaveChangesAsync();
            return flashlight;
        }

        public async Task<List<Flashlight>> SearchFlashlightsByNameAsync(List<string> names)
        {
            var flashlights = context.Flashlights.Include(t => t.Tags).Where(t => names.Contains(t.Name));
            return await flashlights.ToListAsync();
        }

        public async Task<Flashlight?> SearchForFlashlight(string name)
        {
            var flashlight = await context.Flashlights.Include(t => t.Tags).FirstOrDefaultAsync(x => x.Name.Contains(name));
            if (flashlight is null)
            {
                return null;
            }
            return flashlight;
        }

        public async Task<Flashlight?> UpdateFlashlightAsync(UpdateFlashlightRequestDto flashlightrequestDto, int id)
        {
            var flashlight = await context.Flashlights.Include(t => t.Tags).FirstOrDefaultAsync(x => x.Id == id);
            if (flashlight is null)
            {
                return null;
            }
            foreach (var item in flashlightrequestDto.TagIds)
            {
                var tag = await context.Tags.FirstOrDefaultAsync(x => x.Id == item);
                if (tag is not null) 
                    flashlight.Tags.Add(tag);  
            }
            flashlight = flashlightrequestDto.ToFlashlightFromUpdateDto(flashlight);
                        
            context.Flashlights.Update(flashlight);
            await context.SaveChangesAsync();
            return flashlight;
        }
    }
}