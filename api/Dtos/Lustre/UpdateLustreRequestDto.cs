
namespace api.Dtos.Lustre
{
    public class UpdateLustreRequestDto
    {
        public string Name { get; set; } = String.Empty;

        public string Description { get; set; } = String.Empty;

        public string PicLink { get; set; } = String.Empty;

        public decimal Cost { get; set; }

        public string Company { get; set; } = String.Empty;
        
        public int BulbCount { get; set; }

        public int Weight { get; set; }
    }
}