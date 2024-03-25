using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Nightlight;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface INightlightRepository
    {
        Task<List<Nightlight>> GetNightlightsAsync(QueryObject queryObject);

        Task<Nightlight?> GetNightlightByIdAsync(int id);

        Task<Nightlight> CreateNightlightAsync(Nightlight nightlight);

        Task<Nightlight?> UpdateNightlightAsync(UpdateNightlightRequestDto nightlightRequestDto, int id);

        Task<Nightlight?> RemoveNightlight(int id);
    }
}