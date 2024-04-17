using api.Dtos.Product;

namespace api.Dtos.Flashlight
{
    public class GetFlashlightRequestDto : GetProductRequestDto
    {
        public string Version { get; set; } = string.Empty;
    }
}
