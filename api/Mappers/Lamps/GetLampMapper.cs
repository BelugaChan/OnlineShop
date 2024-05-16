using api.Dtos.Lamps;
using api.Models;

namespace api.Mappers.Lamps
{
    public static class GetLampMapper
    {
        public static GetLampRequestDto ToGetDtoFromLamp(this Lamp lamp)
        {
            var tagNames = lamp.Tags.Select(t => t.Name).ToList();
            return new GetLampRequestDto
            {
                Name = lamp.Name,
                Description = lamp.Description,
                PicLink = lamp.PicLink,
                Cost = lamp.Cost,
                Company = lamp.Company,
                Power = lamp.Power,
                TagNames = tagNames
            };
        }

        public static List<GetLampRequestDto> ToGetDtoFromlamp(this List<Lamp> lamps)
        {
            List<GetLampRequestDto> list = new List<GetLampRequestDto>();
            foreach (var item in lamps)
            {
                var tagNames = item.Tags.Select(t => t.Name).ToList();
                list.Add(new GetLampRequestDto()
                {
                    Name = item.Name,
                    Description = item.Description,
                    PicLink = item.PicLink,
                    Cost = item.Cost,
                    Company = item.Company,
                    Power= item.Power,
                    TagNames = tagNames
                });
            }
            return list;
        }
    }
}
