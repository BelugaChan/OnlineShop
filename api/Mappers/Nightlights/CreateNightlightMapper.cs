using api.Dtos.Nightlight;
using api.Models;

namespace api.Mappers.Nightlights
{
    public static class CreateNightlightMapper
    {
        public static Nightlight ToNightlightFromCreateDto(this CreateNightlightRequestDto nightlightRequestDto)
        {
            return new Nightlight
            {
                Name = nightlightRequestDto.Name,
                Description = nightlightRequestDto.Description,
                PicLink = nightlightRequestDto.PicLink,
                Cost = nightlightRequestDto.Cost,
                Company = nightlightRequestDto.Company,
                CountryProduction = nightlightRequestDto.CountryProduction,
                ExpirationDate = nightlightRequestDto.ExpirationDate
            };
        }
    }
}