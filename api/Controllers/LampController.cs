using api.Dtos.Lamp;
using api.Helpers;
using api.Interfaces;
using api.Mappers.Lamps;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/Lamps")]
    [ApiController]
    public class LampController : ControllerBase
    {
        private readonly ILampsRepository lampsRepository;
        private ILogger<LampController> logger;
        public LampController(ILampsRepository lampsRepository, ILogger<LampController> logger)
        {
            this.lampsRepository = lampsRepository;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLamps([FromQuery] QueryObject queryObject)
        {
            var lamps = await lampsRepository.GetAllAsync(queryObject);
            var lampDtos = lamps.ToGetDtoFromlamp();
            return Ok(lampDtos);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetLampById([FromRoute] int id)
        {
            var lamp = await lampsRepository.GetLampByIdAsync(id);
            if (lamp is null) return NotFound();

            var lampDto = lamp.ToGetDtoFromLamp();
            logger.LogInformation("return data for requested lamp: {@lamp}", lamp);
            return Ok(lampDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddLamp([FromBody] CreateLampRequestDto lampRequestDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var lamp = await lampsRepository.CreateLampAsync(lampRequestDto);
            var lampDto = lamp.ToGetDtoFromLamp();
            logger.LogInformation("lamp was created. Data for lamp: {@data}", lampDto);
            return Ok(lampDto);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateLamp([FromBody] UpdateLampRequestDto lampRequestDto, [FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var lamp = await lampsRepository.UpdateLampAsync(id, lampRequestDto);
            if (lamp is null) return NotFound();

            var lampDto = lamp.ToGetDtoFromLamp();
            logger.LogInformation("lamp was updated. Updated data: {data}", lampDto);
            return Ok(lampDto);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteLamp([FromRoute] int id)
        {
            var lamp = await lampsRepository.DeleteLampAsync(id);
            if (lamp is null) return NotFound();

            logger.LogInformation("lamp with id: {id} was deleted", id);
            return NoContent();
        }
    }
}