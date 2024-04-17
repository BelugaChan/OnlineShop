using api.Dtos.Nightlight;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface INightlightRepository
    {
        Task<List<Nightlight>> GetNightlightsAsync(QueryObject queryObject);

        Task<Nightlight?> GetNightlightByIdAsync(int id);

        Task<Nightlight> CreateNightlightAsync(CreateNightlightRequestDto nightlightRequestdto);

        Task<Nightlight?> UpdateNightlightAsync(UpdateNightlightRequestDto nightlightRequestDto, int id);

        Task<Nightlight?> RemoveNightlight(int id);
    }
}