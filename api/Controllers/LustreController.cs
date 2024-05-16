using api.Dtos.Lustres;
using api.Helpers;
using api.Interfaces.Repositories;
using api.Mappers.Lustres;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/Lustre")]
    [ApiController]
    public class LustreController : ControllerBase
    {
        private readonly ILustreRepository lustreRepository;
        public LustreController(ILustreRepository lustreRepository)
        {
            this.lustreRepository = lustreRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject queryObject)
        {
            var lustres = await lustreRepository.GetAllAsync(queryObject);
            var lustresDto = lustres.ToGetDtoFromLustre();
            return Ok(lustresDto);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetItem([FromRoute] int id)
        {
            var lustre = await lustreRepository.GetItemByIdAsync(id);
            if (lustre is null) return NotFound();

            var lustreDto = lustre.ToGetDtoFromLustre();
            return Ok(lustreDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody] CreateLustreRequestDto lustreRequestDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var lustre = await lustreRepository.CreateItemAsync(lustreRequestDto);
            var lustreDto = lustre.ToGetDtoFromLustre();
            return Ok(lustreDto);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateItem([FromRoute] int id, [FromBody] UpdateLustreRequestDto lustreRequestDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var lustre = await lustreRepository.UpdateItemAsync(id, lustreRequestDto);
            if (lustre is null) return NotFound();

            var lustreDto = lustre.ToGetDtoFromLustre();
            return Ok(lustreDto);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteItem([FromRoute] int id)
        {
            var lustreItem = await lustreRepository.DeleteItemAsync(id);
            if (lustreItem is null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}