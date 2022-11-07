using Newtonsoft.Json;

namespace NetTaskGetFront.PolygonStockService.Models
{
    public class AggregatesModel
    {
        [JsonProperty(PropertyName = "request_id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "ticker")]
        public string Ticker { get; set; }
        
        [JsonProperty(PropertyName = "adjusted")]
        public bool Adjusted { get; set; }
        
        [JsonProperty(PropertyName = "queryCount")]
        public int QueryCount { get; set; }
        
        [JsonProperty(PropertyName = "resultsCount")]
        public int ResultsCount { get; set; }
        
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "results")]
        public IEnumerable<AggregatesItemModel> Results { get; set; }
    }
}
