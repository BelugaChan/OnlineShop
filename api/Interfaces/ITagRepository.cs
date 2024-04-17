using api.Dtos.Product;
using api.Models;

namespace api.Interfaces
{
    public interface ITagRepository
    {
        Task<List<Tag>> GetTags();

        Task<Tag?> GetTag(int id);

        Task<List<Tag>> GetProductTags(int productId);

        Task<List<string>> GetProductTagNames(int productId);

    }
}
