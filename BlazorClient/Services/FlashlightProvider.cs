using BlazorClient.Data.Models;
using BlazorClient.Services.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace BlazorClient.Services
{
    public class FlashlightProvider : IFlashlightProvider
    {
        private HttpClient httpClient;

        public FlashlightProvider(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<FlashlightSearch>> GetFlashlightsByTags(List<string> searchTags)
        {
            var response = await httpClient.PostAsJsonAsync($"/api/Flashlight/Search", searchTags);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var resData = JsonConvert.DeserializeObject<List<FlashlightSearch>>(data);
                return resData;
            }
            return null;
        }

        public Task<bool> CreateFlashlightAsync(Flashlight flashlight)
        {
            throw new NotImplementedException();
        }

        public async Task<Flashlight?> GetFlashlightByIdAsync(int id)
        {
            return await httpClient.GetFromJsonAsync<Flashlight>($"/api/Flashlight/{id}");
        }

        public async Task<List<Flashlight>> GetFlashlightsAsync()
        {
            return await httpClient.GetFromJsonAsync<List<Flashlight>>("/api/Flashlight");
        }

        public async Task<List<Tag>> GetFlashlightsTags()
        {
            return await httpClient.GetFromJsonAsync<List<Tag>>("/api/Flashlight/Tags");
        }       

        public Task<bool> RemoveFlashlight(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Flashlight?> SearchForFlashlight(string name)
        { 
            return await httpClient.GetFromJsonAsync<Flashlight>($"/api/Flashlight/{name}");
        }

        public Task<Flashlight?> UpdateFlashlightAsync(Flashlight flashlight, int id)
        {
            throw new NotImplementedException();
        }
    }
}
