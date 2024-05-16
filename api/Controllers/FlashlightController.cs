using api.Dtos.Flashlights;
using api.Helpers;
using api.Interfaces.Repositories;
using api.Interfaces.Services;
using api.Mappers.Flashlights;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/Flashlight")]
    [ApiController]
    public class FlashlightController : ControllerBase
    {
        private ILogger<FlashlightController> logger;
        private readonly IFlashlightRepository flashlightRepository;
        private readonly IAlgorithmService algorithmService;
        private readonly IFlashlightConverterService flashlightConverterService;

        public FlashlightController(IFlashlightRepository flashlightRepository,
        ILogger<FlashlightController> logger, IAlgorithmService algorithmService,
        IFlashlightConverterService flashlightConverterService)
        {
            this.flashlightRepository = flashlightRepository;
            this.logger = logger;
            this.algorithmService = algorithmService;
            this.flashlightConverterService = flashlightConverterService;
        }

        [HttpGet]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetItem([FromRoute] int id)
        {
            var flashlight = await flashlightRepository.GetFlashlightByIdAsync(id);         
            if (flashlight is null) return NotFound();

            var flashlightDto = flashlight.ToGetDtoFromFlashlight();

            logger.LogInformation("requested flashlight with id: {id} is {@flashlight}", id, flashlightDto);
            
            return Ok(flashlightDto);
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<IActionResult> GetItemByName([FromRoute] string name)
        {
            var flashlight = await flashlightRepository.SearchForFlashlight(name);
            if (flashlight is null) return NotFound();

            var flashlightDto = flashlight.ToGetDtoFromFlashlight();

            return Ok(flashlightDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(/*[FromQuery] QueryObject queryObject*/)
        {
            var flashlights = await flashlightRepository.GetFlashlightsAsync(/*queryObject*/);
            var flashlightsDtos = flashlights.ToGetDtoFromFlashlight();
            return Ok(flashlightsDtos);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateItem([FromBody] CreateFlashlightRequestDto flashlightRequestDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var flashlight = await flashlightRepository.CreateFlashlightAsync(flashlightRequestDto);
            var flashlightDto = flashlight.ToGetDtoFromFlashlight();
            logger.LogInformation("flashlight was created. Creation data: {@flashlightDto}", flashlightDto);
            
            return Ok(flashlightDto);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateItem([FromBody] UpdateFlashlightRequestDto flashlightRequestDto,[FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var flashlight = await flashlightRepository.UpdateFlashlightAsync(flashlightRequestDto,id);
            if (flashlight is null) return NotFound();

            var flashlightDto = flashlight.ToGetDtoFromFlashlight();
            logger.LogInformation("flashlight was updated. Updated data: {@flashlightRequestDto}", flashlightDto);

            return Ok(flashlightDto);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteItem([FromRoute] int id)
        {
            var flashlight = await flashlightRepository.RemoveFlashlight(id);
            if (flashlight is null) return NotFound();

            logger.LogInformation("flashlight with {id} was deleted", id);

            return NoContent();
        }

        [HttpPost]
        [Route("Search")]
        public async Task<IActionResult> SearchAmongTags([FromBody] List<string> searchTags)
        {
            var flashlights = await flashlightRepository.GetFlashlightsAsync();

            var items = flashlightConverterService.SearcherForFlashlights(flashlights);
            var data = algorithmService.GetData(searchTags, items);
            var res = flashlightConverterService.GetFlashlightsForTagSearch(data, flashlights);
            return Ok(res);
        }

        [HttpGet]
        [Route("Tags")]
        public async Task<IActionResult> GetAllTags()
        {
            var tags = await flashlightRepository.GetFlashlightsTags();
            return Ok(tags);
        }
    }
}