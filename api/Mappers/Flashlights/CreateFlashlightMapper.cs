using api.Dtos.Flashlight;
using api.Models;

namespace api.Mappers.Flashlights
{
    public static class CreateFlashlightMapper
    {
        public static Flashlight ToFlashlightFromCreateDto(this CreateFlashlightRequestDto flashlightRequestDto)
        {
            Flashlight flashlight = new Flashlight() 
            {
                Name = flashlightRequestDto.Name,
                Description = flashlightRequestDto.Description,
                PicLink = flashlightRequestDto.PicLink,
                Cost = flashlightRequestDto.Cost,
                Company = flashlightRequestDto.Company,
                Version = flashlightRequestDto.Version
            };
            //foreach (var item in flashlightRequestDto.TagIds)
            //{
            //    flashlight.ProductTags.Add(new ProductTag
            //    {
            //        Product = flashlight,
            //        ProductId = flashlight.Id,
            //        TagId = item
            //    });
            //}
            return flashlight;
        }
    }
}