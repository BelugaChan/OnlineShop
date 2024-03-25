using api.Dtos.Lustre;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface ILustreRepository
    {
        Task<List<Lustre>> GetAllAsync(QueryObject queryObject);

        Task<Lustre?> GetItemByIdAsync(int id);

        Task<Lustre> CreateItemAsync(Lustre lustre);

        Task<Lustre?> UpdateItemAsync(int id, UpdateLustreRequestDto lustreDto);

        Task<Lustre?> DeleteItemAsync(int id);
    }
}
