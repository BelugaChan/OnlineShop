namespace BlazorClient.Data.Models
{
    public class FlashlightSearch
    {
        public List<Flashlight> Flashlights { get; set; } = new List<Flashlight>();

        public List<string> Tags { get; set; } = new List<string>();
    }
}
