using api.Dtos.Lustres;
using api.Helpers;
using api.Models;

namespace api.Interfaces.Repositories
{
    public interface ILustreRepository
    {
        Task<List<Lustre>> GetAllAsync(QueryObject queryObject);

        Task<Lustre?> GetItemByIdAsync(int id);

        Task<Lustre> CreateItemAsync(CreateLustreRequestDto lustreRequestDto);

        Task<Lustre?> UpdateItemAsync(int id, UpdateLustreRequestDto lustreDto);

        Task<Lustre?> DeleteItemAsync(int id);
    }
}
