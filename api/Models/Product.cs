using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("Products")]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string PicLink { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Cost { get; set; }

        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}
