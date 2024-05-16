using api.Dtos.Lustres;
using api.Models;

namespace api.Mappers.Lustres
{
    public static class GetLustreMapper
    {
        public static GetLustreRequestDto ToGetDtoFromLustre(this Lustre lustre)
        {
            var tagNames = lustre.Tags.Select(t => t.Name).ToList();
            return new GetLustreRequestDto
            {
                Name = lustre.Name,
                Description = lustre.Description,
                PicLink = lustre.PicLink,
                Cost = lustre.Cost,
                Company = lustre.Company,
                BulbCount = lustre.BulbCount,
                Weight = lustre.Weight,
                TagNames = tagNames
            };
        }

        public static List<GetLustreRequestDto> ToGetDtoFromLustre(this List<Lustre> lustres)
        {
            List<GetLustreRequestDto> list = new List<GetLustreRequestDto>();
            foreach (var item in lustres)
            {
                var tagNames = item.Tags.Select(t => t.Name).ToList();
                list.Add(new GetLustreRequestDto()
                {
                    Name = item.Name,
                    Description = item.Description,
                    PicLink = item.PicLink,
                    Cost = item.Cost,
                    Company = item.Company,
                    BulbCount = item.BulbCount,
                    Weight = item.Weight,
                    TagNames = tagNames
                });
            }
            return list;
        }
    }
}
