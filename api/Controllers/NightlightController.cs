using api.Dtos.Nightlight;
using api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using api.Helpers;
using api.Mappers.Nightlights;
using api.Models;

namespace api.Controllers
{
    [Route("api/Nightlight")]
    [ApiController]
    public class NightlightController : ControllerBase
    {
        private INightlightRepository nightlightRepository;
        public NightlightController(INightlightRepository nightlightRepository)
        {
            this.nightlightRepository = nightlightRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetItems([FromQuery] QueryObject queryObject)
        {
            var nightlights = await nightlightRepository.GetNightlightsAsync(queryObject);
            var nightlightDtos = nightlights.ToGetDtoFromNightlight();
            return Ok(nightlightDtos);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetItemById([FromRoute] int id)
        {
            var nightlight = await nightlightRepository.GetNightlightByIdAsync(id);
            if (nightlight is null) return NotFound();

            var nightlightDtos = nightlight.ToGetDtoFromNightlight();
            return Ok(nightlightDtos);
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateItem([FromBody] UpdateNightlightRequestDto nightlightRequestDto, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var nightlight = await nightlightRepository.UpdateNightlightAsync(nightlightRequestDto, id);
            if (nightlight is null) return NotFound();

            var nightlightDtos = nightlight.ToGetDtoFromNightlight();
            return Ok(nightlightDtos);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> RemoveItem([FromRoute] int id)
        {
            var nightlight = await nightlightRepository.RemoveNightlight(id);
            if (nightlight is null)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody] CreateNightlightRequestDto createNightlightRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var nightlight = await nightlightRepository.CreateNightlightAsync(createNightlightRequestDto);
            var nightlightDtos = nightlight.ToGetDtoFromNightlight();
            return Ok(nightlightDtos);
        }
    }
}