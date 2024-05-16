using api.Dtos.Search;
using api.Helpers;
using api.Interfaces;
using api.Interfaces.Services;
using api.Mappers.Flashlights;
using api.Mappers.Lamps;
using api.Mappers.Lustres;
using api.Mappers.Nightlights;
using api.Models;
using System.Collections;
using System.Linq;

namespace api.Service
{
    public class FlashlightConverterService : IFlashlightConverterService
    {
        public FlashlightConverterService()
        {
        }

        public Dictionary<string, List<string>> SearcherForFlashlights(List<Flashlight> flashlights)
        {
            return flashlights.ToGetDtoFromFlashlight().ToDictionary(t => t.Name, t => t.TagNames);
        }

        public List<GetFlashlightSearchDto> GetFlashlightsForTagSearch(Dictionary<List<string>, List<string>> items, List<Flashlight> flashlights)
        {
            var res = new List<GetFlashlightSearchDto>();
            foreach (var item in items)
            {
                var products = flashlights.Where(t => item.Value.Contains(t.Name)).ToList();                
                res.Add(new GetFlashlightSearchDto()
                {
                    Flashlights = products.ToGetDtoFromFlashlight(),
                    Tags = item.Key
                });
            }
            return res;
        }
    }
}
