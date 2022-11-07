using Newtonsoft.Json;

namespace NetTaskGetFront.PolygonStockService.Models
{
    public class AggregatesItemModel
    {
        [JsonProperty(PropertyName = "c")]
        public decimal ClosePrice { get; set; }
        
        [JsonProperty(PropertyName = "h")]
        public decimal HighestPrice { get; set; }
        
        [JsonProperty(PropertyName = "l")]
        public decimal LowestPrice { get; set; }
        
        [JsonProperty(PropertyName = "n")]
        public int TransactionCount { get; set; }
        
        [JsonProperty(PropertyName = "o")]
        public decimal OpenPrice { get; set; }
        
        [JsonProperty(PropertyName = "otc")]
        public bool IsOTC { get; set; }
        
        [JsonProperty(PropertyName = "t")]
        public long Time { get; set; }
        
        [JsonProperty(PropertyName = "v")]
        public decimal TradingVolume { get; set; }
        
        [JsonProperty(PropertyName = "vw")]
        public decimal VolumeWeightedAveragePrice { get; set; }
    }
}
