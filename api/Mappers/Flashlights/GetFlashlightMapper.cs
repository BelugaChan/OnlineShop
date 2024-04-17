using api.Dtos.Flashlight;
using api.Models;
using Microsoft.Identity.Client;
using System.Linq;

namespace api.Mappers.Flashlights
{
    public static class GetFlashlightMapper
    {
        public static GetFlashlightRequestDto ToGetDtoFromFlashlight(this Flashlight flashlight)
        {
            var tagNames = flashlight.Tags.Select(t => t.Name).ToList();
            return new GetFlashlightRequestDto
            {
                Name = flashlight.Name,
                Description = flashlight.Description,
                PicLink = flashlight.PicLink,
                Cost = flashlight.Cost,
                Company = flashlight.Company,
                Version = flashlight.Version,
                TagNames = tagNames
            };
        }

        public static List<GetFlashlightRequestDto> ToGetDtoFromFlashlight(this List<Flashlight> flashlight)
        {
            List<GetFlashlightRequestDto> list = new List<GetFlashlightRequestDto>();
            foreach (var item in flashlight)
            {
                var tagNames = item.Tags.Select(t => t.Name).ToList();
                list.Add(new GetFlashlightRequestDto()
                {
                    Name = item.Name,
                    Description = item.Description,
                    PicLink = item.PicLink,
                    Cost = item.Cost,
                    Company = item.Company,
                    Version = item.Version,
                    TagNames = tagNames
                });
            }
            return list;
        }
    }
}
