using api.Dtos.Flashlight;
using api.Dtos.Lamp;
using api.Models;

namespace api.Mappers.Lamps
{
    public static class UpdateLampMapper
    {
        public static Lamp ToLampFromUpdateDto(this UpdateLampRequestDto updateLampRequestDto, Lamp lamp)
        {
            lamp.Name = updateLampRequestDto.Name;
            lamp.Description = updateLampRequestDto.Description;
            lamp.PicLink = updateLampRequestDto.PicLink;
            lamp.Company = updateLampRequestDto.Company;
            lamp.Cost = updateLampRequestDto.Cost;
            lamp.Power = updateLampRequestDto.Power;
            return lamp;
        }
    }
}
