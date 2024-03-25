using api.Dtos.Nightlight;
using api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using api.Mappers;
using api.Helpers;

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
            return Ok(nightlights);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetItemById([FromRoute] int id)
        {
            var nightlight = await nightlightRepository.GetNightlightByIdAsync(id);
            if (nightlight is null)
            {
                return NotFound();
            }
            return Ok(nightlight);
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateItem([FromBody] UpdateNightlightRequestDto nightlightRequestDto, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var nightlight = await nightlightRepository.UpdateNightlightAsync(nightlightRequestDto, id);
            if (nightlight is null)
            {
                return NotFound();
            }
            return Ok(nightlight);
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
            
            var nightlight = createNightlightRequestDto.ToNightlightFromCreateDto();
            await nightlightRepository.CreateNightlightAsync(nightlight);
            return CreatedAtAction(nameof(GetItemById), new {id = nightlight.Id});
        }
    }
}