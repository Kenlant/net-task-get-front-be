using NetTaskGetFront.PolygonStockService.Models;
using Refit;

namespace NetTaskGetFront.PolygonStockService
{
    public interface IPoligonHttpClient
    {
        [Get("/v2/aggs/ticker/{stocksTicker}/range/{multiplier}/{timespan}/{from}/{to}?limit=5000")]
        Task<AggregatesModel> GetAggregated(string stocksTicker, int multiplier, string timespan, string from, string to);
    }
}
