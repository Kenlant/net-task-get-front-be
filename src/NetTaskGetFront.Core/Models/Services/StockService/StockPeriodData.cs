using NetTaskGetFront.Core.Enums;

namespace NetTaskGetFront.Core.Models.Services.StockService
{
    public class StockPeriodData
    {
        public long Time { get; set; }
        public decimal Price { get; set; }
        public TimePeriod Period { get; set; }
    }
}
