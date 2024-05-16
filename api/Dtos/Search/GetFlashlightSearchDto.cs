using api.Dtos.Flashlights;
using api.Dtos.Products;
using api.Models;
namespace api.Dtos.Search
{
    public class GetFlashlightSearchDto
    {
        public List<GetFlashlightRequestDto> Flashlights { get; set; }

        public List<string> Tags { get; set; }
    }
}
