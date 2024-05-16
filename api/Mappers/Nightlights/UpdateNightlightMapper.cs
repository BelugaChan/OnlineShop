using api.Dtos.Nightlights;
using api.Models;

namespace api.Mappers.Nightlights
{
    public static class UpdateNightlightMapper
    {
        public static Nightlight ToNightlightFromUpdateDto(this UpdateNightlightRequestDto updateNightlightRequestDto, Nightlight nightlight)
        {
            nightlight.Name = updateNightlightRequestDto.Name;
            nightlight.Description = updateNightlightRequestDto.Description;
            nightlight.PicLink = updateNightlightRequestDto.PicLink;
            nightlight.Company = updateNightlightRequestDto.Company;
            nightlight.Cost = updateNightlightRequestDto.Cost;
            nightlight.ExpirationDate = updateNightlightRequestDto.ExpirationDate;
            nightlight.CountryProduction = updateNightlightRequestDto.CountryProduction;
            return nightlight;
        }
    }
}
