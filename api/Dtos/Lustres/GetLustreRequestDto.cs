using api.Dtos.Products;
using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Lustres
{
    public class GetLustreRequestDto : GetProductRequestDto
    {
        public int BulbCount { get; set; }

        public int Weight { get; set; }
    }
}
