using api.Dtos.Flashlight;
using api.Helpers;
using api.Interfaces;
using api.Mappers.Flashlights;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/Flashlight")]
    [ApiController]
    public class FlashlightController : ControllerBase
    {
        private ILogger<FlashlightController> logger;
        private readonly IFlashlightRepository flashlightRepository;

        public FlashlightController(IFlashlightRepository flashlightRepository,
        ILogger<FlashlightController> logger)
        {
            this.flashlightRepository = flashlightRepository;
            this.logger = logger;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetItem([FromRoute] int id)
        {
            var flashlight = await flashlightRepository.GetFlashlightByIdAsync(id);         
            if (flashlight is null) return NotFound();

            var flashlightDto = flashlight.ToGetDtoFromFlashlight();

            logger.LogInformation("requested flashlight with id: {id} is {@flashlight}", id, flashlightDto);
            
            return Ok(flashlightDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject queryObject)
        {
            var flashlights = await flashlightRepository.GetFlashlightsAsync(queryObject);
            var flashlightsDtos = flashlights.ToGetDtoFromFlashlight();
            return Ok(flashlightsDtos);
        }

        [HttpPost]
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
    }
}