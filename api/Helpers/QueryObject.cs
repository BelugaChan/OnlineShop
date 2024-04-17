
namespace api.Helpers
{
    public class QueryObject
    {
        public string? ItemName { get; set; } = null;

        public string? SortBy { get; set; } = null;
         
        public bool IsDescending { get; set; } = false;
    }
}