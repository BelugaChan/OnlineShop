using api.Dtos.Products;
using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Nightlights
{
    public class GetNightlightRequestDto : GetProductRequestDto
    {
        public string CountryProduction { get; set; } = string.Empty;
        public int ExpirationDate { get; set; }
    }
}
