using BlazorClient.Data.Models;


namespace BlazorClient.Services.Interfaces
{
    public interface IFlashlightProvider
    {
        Task<List<Flashlight>> GetFlashlightsAsync(/*QueryObject queryObject*/);

        Task<List<Tag>> GetFlashlightsTags();

        Task<List<FlashlightSearch>> GetFlashlightsByTags(List<string> searchTags);

        Task<Flashlight?> GetFlashlightByIdAsync(int id);

        Task<Flashlight?> UpdateFlashlightAsync(Flashlight flashlight, int id);

        Task<bool> RemoveFlashlight(int id);

        Task<bool> CreateFlashlightAsync(Flashlight flashlight);

        Task<Flashlight?> SearchForFlashlight(string name);
    }
}
