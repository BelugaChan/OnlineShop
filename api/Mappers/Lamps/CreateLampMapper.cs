using api.Dtos.Lamp;
using api.Models;

namespace api.Mappers.Lamps
{
    public static class CreateLampMapper
    {
        public static Lamp ToLampFromCreateDto(this CreateLampRequestDto lampRequestDto)
        {
            return new Lamp
            {
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