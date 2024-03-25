using api.Dtos.Lamp;
using api.Models;

namespace api.Mappers
{
    public static class LampMapper
    {
        public static Lamps ToLampFromCreateDto(this CreateLampRequestDto lampRequestDto)
        {
            return new Lamps{
                Name = lampRequestDto.Name,
                Description = lampRequestDto.Description,
                PicLink = lampRequestDto.PicLink,
                Cost = lampRequestDto.Cost,
                Company = lampRequestDto.Company,
                Power = lampRequestDto.Power
            };
        }
    }
}