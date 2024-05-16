using api.Dtos.Products;
using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Lamps
{
    public class GetLampRequestDto : GetProductRequestDto
    {
        [Range(0.5, 10000)]
        public int Power { get; set; }

        public List<string> TagNames { get; set; }
    }
}
