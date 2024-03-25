using api.Dtos.Lustre;
using api.Models;

namespace api.Mappers
{
    public static class LustreMapper
    {
        public static Lustre ToLustreFromCreateDto(this CreateLustreRequestDto lustreDto)
        {
            return new Lustre
            {
                Name = lustreDto.Name,
                Description = lustreDto.Description,
                PicLink = lustreDto.PicLink,
                Cost = lustreDto.Cost,
                Company = lustreDto.Company,
                BulbCount = lustreDto.BulbCount,
                Weight = lustreDto.Weight
            };
        }
    }
}