using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Nightlight;
using api.Models;

namespace api.Mappers
{
    public static class NightlightMapper
    {
        public static Nightlight ToNightlightFromCreateDto(this CreateNightlightRequestDto nightlightRequestDto)
        {
            return new Nightlight{
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