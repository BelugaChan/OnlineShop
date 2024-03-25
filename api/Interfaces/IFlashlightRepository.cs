using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Flashlight;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IFlashlightRepository
    {
        Task<List<Flashlight>> GetFlashlightsAsync(QueryObject queryObject);

        Task<Flashlight?> GetFlashlightByIdAsync(int id);

        Task<Flashlight?> UpdateFlashlightAsync(UpdateFlashlightRequestDto flashlightrequestDto, int id);

        Task<Flashlight?> RemoveFlashlight(int id);

        Task<Flashlight> CreateFlashlightAsync (Flashlight flashlight);
    }
}