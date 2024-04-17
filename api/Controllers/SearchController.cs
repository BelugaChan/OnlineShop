using api.Helpers;
using api.Interfaces;
using api.Mappers.Flashlights;
using api.Mappers.Search;
using api.Service;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/Search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IFlashlightRepository flashlightRepository;
        private readonly ILampsRepository lampsRepository;
        private readonly ILustreRepository lustreRepository;
        private readonly INightlightRepository nightlightRepository;
        private readonly IAlgorithmService algorithmService;

        public SearchController(IFlashlightRepository flashlightRepository, ILampsRepository lampsRepository,
            ILustreRepository lustreRepository, INightlightRepository nightlightRepository, IAlgorithmService algorithmService)
        {
            this.flashlightRepository = flashlightRepository;
            this.lampsRepository = lampsRepository;
            this.lustreRepository = lustreRepository;
            this.nightlightRepository = nightlightRepository;
            this.algorithmService = algorithmService;
        }

        [HttpPost]
        public async Task<IActionResult> SearchAmongTags([FromBody] List<string> searchTags, [FromQuery] QueryObject queryObject)
        {
            ProductConverter productConverter = new ProductConverter(flashlightRepository, lampsRepository,
                lustreRepository, nightlightRepository);
            var items = await productConverter.Searcher(queryObject);
            var data = algorithmService.GetData(searchTags, items);
            var searchDto = data.FromDictToSearchDtos();
            return Ok(searchDto);
        }
    }
}
