using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Nightlight;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class NightlightRepository : INightlightRepository
    {
        private ApplicationDBContext context;
        public NightlightRepository(ApplicationDBContext context)
        {
            this.context = context;
        }
        public async Task<Nightlight> CreateNightlightAsync(Nightlight nightlight)
        {
            await context.Nightlights.AddAsync(nightlight);
            await context.SaveChangesAsync();
            return nightlight;
        }

        public async Task<Nightlight?> GetNightlightByIdAsync(int id)
        {
            var nightlight = await context.Nightlights.FindAsync(id);
            if (nightlight == null)
            {
                return null;
            }
            return nightlight;
        }

        public async Task<List<Nightlight>> GetNightlightsAsync(QueryObject queryObject)
        {
            var nightlights = context.Nightlights.AsQueryable();
            if (!string.IsNullOrWhiteSpace(queryObject.ItemName))
            {
                nightlights = nightlights.Where(t => t.Name.Contains(queryObject.ItemName));
            }
            if (!string.IsNullOrWhiteSpace(queryObject.SortBy))
            {
                if (queryObject.SortBy.ToLower().Equals("cost"))
                {
                    nightlights = queryObject.IsDescending ? nightlights.OrderByDescending(t => t.Cost)
                    : nightlights.OrderBy(t => t.Cost);
                }
            }
            return await nightlights.ToListAsync();
        }

        public async Task<Nightlight?> RemoveNightlight(int id)
        {
            var nightlight = await context.Nightlights.FindAsync(id);
            if (nightlight == null)
            {
                return null;
            }
            context.Nightlights.Remove(nightlight);
            await context.SaveChangesAsync();
            return nightlight;
        }

        public async Task<Nightlight?> UpdateNightlightAsync(UpdateNightlightRequestDto nightlightRequestDto, int id)
        {
             var nightlight = await context.Nightlights.FindAsync(id);
            if (nightlight == null)
            {
                return null;
            }
            nightlight.Name = nightlightRequestDto.Name;
            nightlight.Description = nightlightRequestDto.Description;
            nightlight.PicLink = nightlightRequestDto.PicLink;
            nightlight.Cost = nightlightRequestDto.Cost;
            nightlight.Company = nightlightRequestDto.Company;
            nightlight.CountryProduction = nightlightRequestDto.CountryProduction;
            nightlight.ExpirationDate = nightlightRequestDto.ExpirationDate;
            context.Nightlights.Update(nightlight);
            await context.SaveChangesAsync();
            return nightlight;
        }
    }
}