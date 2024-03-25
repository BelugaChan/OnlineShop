using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Flashlight;
using api.Models;

namespace api.Mappers
{
    public static class FlashlightMapper
    {
        public static Flashlight ToFlashlightFromCreateDto(this CreateFlashlightRequestDto flashlightRequestDto)
        {
            return new Flashlight{
                Name = flashlightRequestDto.Name,
                Description = flashlightRequestDto.Description,
                PicLink = flashlightRequestDto.PicLink,
                Cost = flashlightRequestDto.Cost,
                Company = flashlightRequestDto.Company,
                Version = flashlightRequestDto.Version
            };
        }
    }
}