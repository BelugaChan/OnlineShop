using api.Dtos.Flashlight;
using api.Dtos.Lamp;
using api.Helpers;
using api.Models;

namespace api.Interfaces
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