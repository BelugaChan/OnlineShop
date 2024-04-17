using api.Dtos.Product;
using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Lustre
{
    public class GetLustreRequestDto : GetProductRequestDto
    {
        public int BulbCount { get; set; }

        public int Weight { get; set; }
    }
}
