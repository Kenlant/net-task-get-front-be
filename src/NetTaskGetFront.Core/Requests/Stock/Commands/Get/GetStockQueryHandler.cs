using MediatR;
using NetTaskGetFront.Core.Interfaces.Processors;
using NetTaskGetFront.Core.Interfaces.Services;
using NetTaskGetFront.Core.Models.Processors;

namespace NetTaskGetFront.Core.Requests.Stock.Commands.Get
{
    public class GetStockQueryHandler : IRequestHandler<GetStockQuery, GetStockViewModel>
    {
        private const string SAndPTicker = "SPY";
        private const int DaysPerWeek = 7;

        private readonly IStockService _stockService;
        private readonly IStockProcessor _stockProcessor;

        public GetStockQueryHandler(IStockService stockService, IStockProcessor stockProcessor)
        {
            _stockService = stockService;
            _stockProcessor = stockProcessor;
        }

        public async Task<GetStockViewModel> Handle(GetStockQuery request, CancellationToken cancellationToken)
        {
            var now = DateTimeOffset.UtcNow;
            var startDate = now.AddDays(-DaysPerWeek);
            var defaultStockData = await _stockService.Get(SAndPTicker, request.Period, startDate, now);
            var requestedStockData = await _stockService.Get(request.Ticker, request.Period, startDate, now);

            var result = new GetStockViewModel
            {
                StockPerfomance = new List<StockPerfomance>
                {
                    await _stockProcessor.CalculatePerfomance(defaultStockData),
                    await _stockProcessor.CalculatePerfomance(requestedStockData)
                }
            };

            return result;
        }
    }
}
