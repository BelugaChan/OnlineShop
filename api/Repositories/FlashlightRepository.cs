using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Flashlight;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class FlashlightRepository : IFlashlightRepository
    {
        private readonly ApplicationDBContext context;
        public FlashlightRepository(ApplicationDBContext context)
        {
            this.context = context;
        }
        public async Task<Flashlight> CreateFlashlightAsync(Flashlight flashlight)
        {
            await context.Flashlights.AddAsync(flashlight);
            await context.SaveChangesAsync();
            return flashlight;
        }

        public async Task<Flashlight?> GetFlashlightByIdAsync(int id)
        {
            var flashlight = await context.Flashlights.FindAsync(id);
            if (flashlight == null)
            {
                return null;
            }
            return flashlight;
        }

        public async Task<List<Flashlight>> GetFlashlightsAsync(QueryObject queryObject)
        {
            var flashlgihts = context.Flashlights.AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryObject.ItemName))
            {
                flashlgihts = flashlgihts.Where(t => t.Name.Contains(queryObject.ItemName));
            }

            if (!string.IsNullOrWhiteSpace(queryObject.SortBy))
            {
                if (queryObject.SortBy.ToLower().Equals("cost"))
                {
                    flashlgihts = queryObject.IsDescending ? flashlgihts.OrderByDescending(t => t.Cost) 
                    : flashlgihts.OrderBy(t => t.Cost);
                }
            }
            return await flashlgihts.ToListAsync();
        }

        public async Task<Flashlight?> RemoveFlashlight(int id)
        {
            var flashlight = await context.Flashlights.FirstOrDefaultAsync(t => t.Id == id);
            if (flashlight == null)
            {
                return null;
            }
            context.Flashlights.Remove(flashlight);
            await context.SaveChangesAsync();
            return flashlight;
        }

        public async Task<Flashlight?> UpdateFlashlightAsync(UpdateFlashlightRequestDto flashlightrequestDto, int id)
        {
            var flashlight = await context.Flashlights.FirstOrDefaultAsync(t => t.Id == id);
            if (flashlight == null)
            {
                return null;
            }
            flashlight.Name = flashlightrequestDto.Name;
            flashlight.Description = flashlightrequestDto.Description;
            flashlight.PicLink = flashlightrequestDto.PicLink;
            flashlight.Company = flashlightrequestDto.Company;
            flashlight.Cost = flashlightrequestDto.Cost;
            flashlight.Version = flashlightrequestDto.Version;

            context.Flashlights.Update(flashlight);
            await context.SaveChangesAsync();
            return flashlight;
        }
    }
}