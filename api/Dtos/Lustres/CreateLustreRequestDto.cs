using api.Dtos.Products;
using System.ComponentModel.DataAnnotations;


namespace api.Dtos.Lustres
{
    public class CreateLustreRequestDto : CreateProductRequestDto
    {
        [Range(1,100)]
        public int BulbCount { get; set; }

        [Range(1,100)]
        public int Weight { get; set; }
    }
}