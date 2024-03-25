using api.Dtos.Lustre;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
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
            return Ok(lustres);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetItem([FromRoute] int id)
        {
            var lustre = await lustreRepository.GetItemByIdAsync(id);

            if (lustre is null)
            {
                return NotFound();
            }

            return Ok(lustre);
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody] CreateLustreRequestDto lustreDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var lustreItem = lustreDto.ToLustreFromCreateDto();
            await lustreRepository.CreateItemAsync(lustreItem);
            return CreatedAtAction(nameof(GetItem), new {id = lustreItem.Id});
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateItem([FromRoute] int id, [FromBody] UpdateLustreRequestDto lustreDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var lustreItem = await lustreRepository.UpdateItemAsync(id, lustreDto);
            if (lustreItem is null)
            {
                return NotFound();
            }
            return Ok(lustreItem);
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