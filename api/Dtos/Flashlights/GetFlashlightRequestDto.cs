using api.Dtos.Products;

namespace api.Dtos.Flashlights
{
    public class GetFlashlightRequestDto : GetProductRequestDto
    {
        public string Version { get; set; } = string.Empty;
    }
}
