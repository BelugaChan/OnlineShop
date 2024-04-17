using api.Dtos.Search;

namespace api.Mappers.Search
{
    public static class GetSearchMapper
    {
        public static List<GetSearchDto> FromDictToSearchDtos(this Dictionary<List<string>, List<string>> data)
        {
            var res = new List<GetSearchDto>();
            foreach (var item in data)
            {
                res.Add(new GetSearchDto()
                {
                    Products = item.Value,
                    Tags = item.Key
                });
            }
            return res;
        }
    }
}
