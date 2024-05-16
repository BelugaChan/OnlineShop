using api.Interfaces.Services;
using BronKerboshAlgorithm;

namespace api.Service
{
    public class BronKerboschService : IAlgorithmService
    {
        public Dictionary<List<string>, List<string>> GetData(List<string> searchTags, Dictionary<string, List<string>> products)
        {
            ProductGraph productGraph = new ProductGraph(searchTags);
            foreach (var item in products)
            {
                productGraph.AddProduct(item.Key, item.Value);
            }

            var graph = productGraph.GetGraph();

            BronKerbosch bronKerbosch = new BronKerbosch();
            bronKerbosch.FindAllMaximalCliques(graph);
            var cliques = bronKerbosch.GetCliques();

            Identifier identifier = new Identifier(products);
            var resData = identifier.CompareTagsWithCliques(searchTags, cliques);
            return resData;
        }
    }
}
