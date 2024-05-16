namespace api.Interfaces.Services
{
    public interface IAlgorithmService
    {
        Dictionary<List<string>, List<string>> GetData(List<string> searchTags, Dictionary<string, List<string>> products);
    }
}
