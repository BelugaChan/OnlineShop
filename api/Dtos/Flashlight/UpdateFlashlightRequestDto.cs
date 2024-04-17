using api.Dtos.Product;
using System.ComponentModel.DataAnnotations;


namespace api.Dtos.Flashlight
{
    public class UpdateFlashlightRequestDto : UpdateProductRequestDto
    {
        [Required]
        [Range(0, int.MaxValue)]
        public string Version { get; set; } = string.Empty;
    }
}