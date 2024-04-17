using api.Dtos.Product;
using System.ComponentModel.DataAnnotations;


namespace api.Dtos.Nightlight
{
    public class CreateNightlightRequestDto : CreateProductRequestDro
    {      
        [MinLength(3, ErrorMessage = "CountryName must be at least 3 characters")]
        [MaxLength(50, ErrorMessage = "CountryName cannot be over 50 characters")]
        public string CountryProduction { get; set; } = string.Empty;

        [Range(1,100)]
        public int ExpirationDate { get; set; }
    }
}