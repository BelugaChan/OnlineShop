using api.Models;
using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Product
{
    public class GetProductRequestDto
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string PicLink { get; set; } = string.Empty;

        public decimal Cost { get; set; }

        public string Company { get; set; } = string.Empty;

        public List<string> TagNames { get; set; }
    }
}
