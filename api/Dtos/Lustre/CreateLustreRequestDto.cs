using api.Dtos.Product;
using System.ComponentModel.DataAnnotations;


namespace api.Dtos.Lustre
{
    public class CreateLustreRequestDto : CreateProductRequestDro
    {
        [Range(1,100)]
        public int BulbCount { get; set; }

        [Range(1,100)]
        public int Weight { get; set; }
    }
}