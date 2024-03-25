using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Lamp;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface ILampsRepository
    {
        Task<List<Lamps>> GetAllAsync(QueryObject queryObject);

        Task<Lamps?> GetLampByIdAsync(int id);

        Task<Lamps?> UpdateLampAsync(int id, UpdateLampRequestDto lampRequestDto);

        Task<Lamps> CreateLampAsync(Lamps lamp);

        Task<Lamps?> DeleteLampAsync(int id);
    }
}