using api.Dtos.Lamp;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/Lamps")]
    [ApiController]
    public class LampController : ControllerBase
    {
        private readonly ILampsRepository lampsRepository;

        public LampController(ILampsRepository lampsRepository)
        {
            this.lampsRepository = lampsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLamps([FromQuery] QueryObject queryObject)
        {
            var lamps = await lampsRepository.GetAllAsync(queryObject);
            return Ok(lamps);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetLampById([FromRoute] int id)
        {
            var lamp = await lampsRepository.GetLampByIdAsync(id);
            if (lamp is null)
            {
                return NotFound();
            }
            return Ok(lamp);
        }

        [HttpPost]
        public async Task<IActionResult> AddLamp([FromBody] CreateLampRequestDto lampRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var lamp = lampRequestDto.ToLampFromCreateDto();
            await lampsRepository.CreateLampAsync(lamp);
            return CreatedAtAction(nameof(GetLampById), new {id = lamp.Id});
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateLamp([FromBody] UpdateLampRequestDto lampRequestDto, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var lamp = await lampsRepository.UpdateLampAsync(id, lampRequestDto);
            if (lamp is null)
            {
                return NotFound();
            }
            return Ok(lamp);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteLamp([FromRoute] int id)
        {
            var lamp = await lampsRepository.DeleteLampAsync(id);
            if (lamp is null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}