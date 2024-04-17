using api.Dtos.Lamp;
using api.Dtos.Lustre;
using api.Models;

namespace api.Mappers.Lustres
{
    public static class UpdateLustreMapper
    {
        public static Lustre ToLustreFromUpdateDto(this UpdateLustreRequestDto updateLustreRequestDto, Lustre lustre)
        {
            lustre.Name = updateLustreRequestDto.Name;
            lustre.Description = updateLustreRequestDto.Description;
            lustre.PicLink = updateLustreRequestDto.PicLink;
            lustre.Company = updateLustreRequestDto.Company;
            lustre.Cost = updateLustreRequestDto.Cost;
            lustre.Weight = updateLustreRequestDto.Weight;
            lustre.BulbCount = updateLustreRequestDto.BulbCount;
            return lustre;
        }
    }
}
