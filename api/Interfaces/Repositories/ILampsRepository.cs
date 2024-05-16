using api.Dtos.Lamps;
using api.Helpers;
using api.Models;

namespace api.Interfaces.Repositories
{
    public interface ILampsRepository
    {
        Task<List<Lamp>> GetAllAsync(QueryObject queryObject);

        Task<Lamp?> GetLampByIdAsync(int id);

        Task<Lamp?> UpdateLampAsync(int id, UpdateLampRequestDto lampRequestDto);

        Task<Lamp> CreateLampAsync(CreateLampRequestDto lampRequestDto);

        Task<Lamp?> DeleteLampAsync(int id);
    }
}