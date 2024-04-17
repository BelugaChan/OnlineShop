using api.Interfaces;
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

            //productGraph.AddProduct("Телевизор", new List<string> { "Электроника", "4K", "Smart TV" });
            //productGraph.AddProduct("Наушники", new List<string> { "Электроника", "Bluetooth", "Беспроводные" });
            //productGraph.AddProduct("Ноутбук", new List<string> { "Электроника", "Windows", "SSD", "Intel Core" });
            //productGraph.AddProduct("Смарт ТВ", new List<string> { "Windows", "3K", "Smart TV" });
            //productGraph.AddProduct("Телефон", new List<string> { "Android", "SnapDragon" });
            //var products = productGraph.GetTags();


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
