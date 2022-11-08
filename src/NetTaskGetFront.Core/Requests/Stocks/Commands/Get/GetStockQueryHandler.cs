using MediatR;
using NetTaskGetFront.Core.Interfaces.Processors;
using NetTaskGetFront.Core.Interfaces.Repositories;
using NetTaskGetFront.Core.Interfaces.Services;

namespace NetTaskGetFront.Core.Requests.Stocks.Commands.Get
{
    public class GetStockQueryHandler : IRequestHandler<GetStockQuery, GetStockViewModel>
    {
        private const string SAndPTicker = "SPY";
        private const int DaysPerWeek = 7;

        private readonly IStockService _stockService;
        private readonly IStockProcessor _stockProcessor;
        private readonly IStockRepository _stockRepository;

        public GetStockQueryHandler(IStockService stockService,
            IStockProcessor stockProcessor,
            IStockRepository stockRepository)
        {
            _stockService = stockService;
            _stockProcessor = stockProcessor;
            _stockRepository = stockRepository;
        }

        public async Task<GetStockViewModel> Handle(GetStockQuery request, CancellationToken cancellationToken)
        {
            var now = DateTimeOffset.UtcNow;
            var startDate = now.AddDays(-DaysPerWeek);
            var defaultStockData = await _stockService.GetAsync(SAndPTicker, request.Period, startDate, now);
            var requestedStockData = await _stockService.GetAsync(request.Ticker, request.Period, startDate, now);

            var stocks = defaultStockData.Concat(requestedStockData);
            await _stockRepository.CreateBatchAsync(stocks, cancellationToken);

            var result = new GetStockViewModel
            {
                StockPerfomance = await _stockProcessor.CalculatePerfomanceAsync(stocks)
            };

            return result;
        }
    }
}
