using api.Dtos.Flashlight;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/Flashlight")]
    [ApiController]
    public class FlashlightController : ControllerBase
    {
        private readonly IFlashlightRepository flashlightRepository;
        public FlashlightController(IFlashlightRepository flashlightRepository)
        {
            this.flashlightRepository = flashlightRepository;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetItem([FromRoute] int id)
        {
            var flashlight = await flashlightRepository.GetFlashlightByIdAsync(id);
            if (flashlight is null)
            {
                return NotFound();
            }
            return Ok(flashlight);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject queryObject)
        {
            var flashlights = await flashlightRepository.GetFlashlightsAsync(queryObject);
            return Ok(flashlights);
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody] CreateFlashlightRequestDto flashlightRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var flashlight = flashlightRequestDto.ToFlashlightFromCreateDto();
            await flashlightRepository.CreateFlashlightAsync(flashlight);
            return CreatedAtAction(nameof(GetItem), new {id = flashlight.Id});
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateItem([FromBody] UpdateFlashlightRequestDto flashlightRequestDto,[FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var flashlight = await flashlightRepository.UpdateFlashlightAsync(flashlightRequestDto,id);
            if (flashlight is null)
            {
                return NotFound();
            }
            return Ok(flashlight);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteItem([FromRoute] int id)
        {
            var flashlight = await flashlightRepository.RemoveFlashlight(id);
            if (flashlight is null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}