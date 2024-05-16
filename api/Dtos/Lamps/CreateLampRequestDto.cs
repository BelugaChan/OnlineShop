using api.Dtos.Products;
using System.ComponentModel.DataAnnotations;


namespace api.Dtos.Lamps
{
    public class CreateLampRequestDto : CreateProductRequestDto
    {
        [Range(0.5, 10000)]
        public int Power { get; set; }
    }
}