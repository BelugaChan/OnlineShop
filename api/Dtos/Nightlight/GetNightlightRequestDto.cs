using api.Dtos.Product;
using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Nightlight
{
    public class GetNightlightRequestDto : GetProductRequestDto
    {
        public string CountryProduction { get; set; } = string.Empty;
        public int ExpirationDate { get; set; }
    }
}
