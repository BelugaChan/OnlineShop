using api.Dtos.Search;
using api.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace api.Interfaces.Services
{
    public interface IFlashlightConverterService
    {
        Dictionary<string, List<string>> SearcherForFlashlights(List<Flashlight> flashlights);

        List<GetFlashlightSearchDto> GetFlashlightsForTagSearch(Dictionary<List<string>, List<string>> items, List<Flashlight> flashlights);
    }
}
