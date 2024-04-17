using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("Tags")]
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
    }
}
