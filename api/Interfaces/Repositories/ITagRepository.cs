using api.Dtos.Products;
using api.Models;

namespace api.Interfaces.Repositories
{
    public interface ITagRepository
    {
        Task<List<Tag>> GetTags();

        Task<Tag?> GetTag(int id);

    }
}
