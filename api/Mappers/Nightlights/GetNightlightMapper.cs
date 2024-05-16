using api.Dtos.Nightlights;
using api.Models;

namespace api.Mappers.Nightlights
{
    public static class GetNightlightMapper
    {
        public static GetNightlightRequestDto ToGetDtoFromNightlight(this Nightlight nightlight)
        {
            var tagNames = nightlight.Tags.Select(t => t.Name).ToList();
            return new GetNightlightRequestDto
            {
                Name = nightlight.Name,
                Description = nightlight.Description,
                PicLink = nightlight.PicLink,
                Cost = nightlight.Cost,
                Company = nightlight.Company,
                CountryProduction = nightlight.CountryProduction,
                ExpirationDate = nightlight.ExpirationDate,
                TagNames = tagNames
            };
        }

        public static List<GetNightlightRequestDto> ToGetDtoFromNightlight(this List<Nightlight> nightlights)
        {
            List<GetNightlightRequestDto> list = new List<GetNightlightRequestDto>();
            foreach (var item in nightlights)
            {
                var tagNames = item.Tags.Select(t => t.Name).ToList();
                list.Add(new GetNightlightRequestDto()
                {
                    Name = item.Name,
                    Description = item.Description,
                    PicLink = item.PicLink,
                    Cost = item.Cost,
                    Company = item.Company,
                    CountryProduction = item.CountryProduction,
                    ExpirationDate = item.ExpirationDate,
                    TagNames = tagNames
                });
            }
            return list;
        }
    }
}
