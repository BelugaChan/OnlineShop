using api.Helpers;
using api.Interfaces;
using api.Mappers.Flashlights;
using api.Mappers.Lamps;
using api.Mappers.Lustres;
using api.Mappers.Nightlights;
using System.Collections;

namespace api.Service
{
    public class ProductConverter
    {
        private readonly IFlashlightRepository flashlightRepository;
        private readonly ILampsRepository lampsRepository;
        private readonly ILustreRepository lustreRepository;
        private readonly INightlightRepository nightlightRepository;
        public ProductConverter(IFlashlightRepository flashlightRepository, ILampsRepository lampsRepository,
            ILustreRepository lustreRepository, INightlightRepository nightlightRepository)
        {
            this.flashlightRepository = flashlightRepository;
            this.lampsRepository = lampsRepository;
            this.lustreRepository = lustreRepository;
            this.nightlightRepository = nightlightRepository;
        }

        public async Task<Dictionary<string,List<string>>> Searcher(QueryObject queryObject)
        {

            var flashlights = await flashlightRepository.GetFlashlightsAsync(queryObject);
            var flashlightsData = flashlights.ToGetDtoFromFlashlight().ToDictionary(t => t.Name, t => t.TagNames);

            var lamps = await lampsRepository.GetAllAsync(queryObject);
            var lampsData = lamps.ToGetDtoFromlamp().ToDictionary(t => t.Name, t => t.TagNames);

            var lustres = await lustreRepository.GetAllAsync(queryObject);
            var lustresData = lustres.ToGetDtoFromLustre().ToDictionary(t => t.Name, t => t.TagNames);

            var nightlights = await nightlightRepository.GetNightlightsAsync(queryObject);
            var nightlightsData = nightlights.ToGetDtoFromNightlight().ToDictionary(t => t.Name, t => t.TagNames);

            var mergedDict = flashlightsData.Concat(lampsData).Concat(lustresData).Concat(nightlightsData).ToDictionary();

            return mergedDict;
        }
    }
}
