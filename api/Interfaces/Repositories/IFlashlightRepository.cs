using api.Dtos.Flashlights;
using api.Models;

namespace api.Interfaces.Repositories
{
    public interface IFlashlightRepository
    {
        Task<List<Flashlight>> GetFlashlightsAsync(/*QueryObject queryObject*/);

        Task<Flashlight?> GetFlashlightByIdAsync(int id);

        Task<Flashlight?> UpdateFlashlightAsync(UpdateFlashlightRequestDto flashlightrequestDto, int id);

        Task<Flashlight?> RemoveFlashlight(int id);

        Task<Flashlight> CreateFlashlightAsync(CreateFlashlightRequestDto flashlight);

        Task<Flashlight?> SearchForFlashlight(string name);

        Task<List<Flashlight>> SearchFlashlightsByNameAsync(List<string> names);

        Task<List<Tag>> GetFlashlightsTags();
    }
}