using NetTaskGetFront.Domain.Enums;

namespace NetTaskGetFront.Domain.Entities
{
    public class Stock
    {
        public int Id { get; set; }
        public string Ticker { get; set; }
        public decimal Price { get; set; }
        public long Timestamp { get; set; }
        public TimePeriod Timeperiod { get; set; }
    }
}
