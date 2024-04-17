using api.Dtos.Product;
using System.ComponentModel.DataAnnotations;


namespace api.Dtos.Lamp
{
    public class UpdateLampRequestDto : UpdateProductRequestDto
    {
        [Range(0.5, 10000)]
        public int Power { get; set; }
    }
}