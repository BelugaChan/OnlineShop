using api.Dtos.Products;
using System.ComponentModel.DataAnnotations;


namespace api.Dtos.Flashlights
{
    public class CreateFlashlightRequestDto : CreateProductRequestDto
    {
        [Required]
        [Range(0, int.MaxValue)]
        public string Version { get; set; } = string.Empty;
    }
}