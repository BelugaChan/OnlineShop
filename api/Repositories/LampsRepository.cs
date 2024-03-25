using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Lamp;
using api.Helpers;
using api.Interfaces;
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

        public async Task<Lamps> CreateLampAsync(Lamps lamp)
        {
            await context.Lamps.AddAsync(lamp);
            await context.SaveChangesAsync();
            return lamp;
        }

        public async Task<Lamps?> DeleteLampAsync(int id)
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

        public async Task<List<Lamps>> GetAllAsync(QueryObject queryObject)
        {
            var lamps = context.Lamps.AsQueryable();
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

        public async Task<Lamps?> GetLampByIdAsync(int id)
        {
            return await context.Lamps.FindAsync(id);
        }

        public async Task<Lamps?> UpdateLampAsync(int id, UpdateLampRequestDto lampRequestDto)
        {
            var lamp = await context.Lamps.FirstOrDefaultAsync(t => t.Id == id);
            if (lamp == null)
            {
                return null;
            }
            lamp.Name = lampRequestDto.Name;
            lamp.Description = lampRequestDto.Description;
            lamp.PicLink = lampRequestDto.PicLink;
            lamp.Company = lampRequestDto.Company;
            lamp.Cost = lampRequestDto.Cost;
            lamp.Power = lampRequestDto.Power;

            context.Lamps.Update(lamp);
            await context.SaveChangesAsync();
            return lamp;
        }
    }
}