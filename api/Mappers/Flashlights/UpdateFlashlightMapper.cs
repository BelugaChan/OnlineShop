using api.Dtos.Flashlight;
using api.Models;

namespace api.Mappers.Flashlights
{
    public static class UpdateFlashlightMapper
    {
        public static Flashlight ToFlashlightFromUpdateDto(this UpdateFlashlightRequestDto updateFlashlightRequestDto, Flashlight flashlight)
        {
            flashlight.Name = updateFlashlightRequestDto.Name;
            flashlight.Description = updateFlashlightRequestDto.Description;
            flashlight.PicLink = updateFlashlightRequestDto.PicLink;
            flashlight.Company = updateFlashlightRequestDto.Company;
            flashlight.Cost = updateFlashlightRequestDto.Cost;
            flashlight.Version = updateFlashlightRequestDto.Version;            
            return flashlight;
        }
    }
}
