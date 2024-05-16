using api.Models;
using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Products
{
    public class UpdateProductRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters")]
        [MaxLength(50, ErrorMessage = "Name cannot be over 50 characters")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MinLength(3, ErrorMessage = "Description must be at least 3 characters")]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string PicLink { get; set; } = string.Empty;

        [Required]
        [Range(1, 100000)]
        public decimal Cost { get; set; }

        [Required]
        public string Company { get; set; } = string.Empty;

        [Required]
        public int[] TagIds { get; set; }

    }
}
