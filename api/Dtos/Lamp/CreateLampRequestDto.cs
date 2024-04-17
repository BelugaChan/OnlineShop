using api.Dtos.Product;
using System.ComponentModel.DataAnnotations;


namespace api.Dtos.Lamp
{
    public class CreateLampRequestDto : CreateProductRequestDro
    {
        [Range(0.5, 10000)]
        public int Power { get; set; }
    }
}