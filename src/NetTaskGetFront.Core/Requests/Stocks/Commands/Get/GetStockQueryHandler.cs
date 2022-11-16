using MediatR;
using NetTaskGetFront.Core.Interfaces.Processors;
using NetTaskGetFront.Core.Interfaces.Repositories;
using NetTaskGetFront.Core.Interfaces.Services;
using NetTaskGetFront.Domain.Entities;

namespace NetTaskGetFront.Core.Requests.Stocks.Commands.Get
{
    public class GetStockQueryHandler : IRequestHandler<GetStockQuery, GetStockViewModel>
    {
        private const string SAndPTicker = "SPY";
        private const int DaysPerWeek = 7;

        private readonly IStockService _stockService;
        private readonly IStockProcessor _stockProcessor;
        private readonly IStockRepository _stockRepository;
        private readonly ITimeProvider _timeProvider;

        public GetStockQueryHandler(IStockService stockService,
            IStockProcessor stockProcessor,
            IStockRepository stockRepository,
            ITimeProvider timeProvider)
        {
            _stockService = stockService;
            _stockProcessor = stockProcessor;
            _stockRepository = stockRepository;
            _timeProvider = timeProvider;
        }

        public async Task<GetStockViewModel> Handle(GetStockQuery request, CancellationToken cancellationToken)
        {
            var now = _timeProvider.Now;
            var startDate = now.AddDays(-DaysPerWeek);
            var defaultStockData = await _stockRepository.GetListAsync(SAndPTicker, startDate.ToUnixTimeMilliseconds(), now.ToUnixTimeMilliseconds());
            var dataToStore = new List<Stock>();
            if (!defaultStockData.Any())
            {
                defaultStockData = await _stockService.GetAsync(SAndPTicker, request.Period, startDate, now);
                dataToStore.AddRange(defaultStockData);
            }

            var requestedStockData = await _stockRepository.GetListAsync(request.Ticker, startDate.ToUnixTimeMilliseconds(), now.ToUnixTimeMilliseconds());
            if (!requestedStockData.Any())
            {
                requestedStockData = await _stockService.GetAsync(request.Ticker, request.Period, startDate, now);
                dataToStore.AddRange(requestedStockData);
            }

            if (dataToStore.Any())
            {
                await _stockRepository.CreateBatchAsync(dataToStore, cancellationToken);
            }

            var result = new GetStockViewModel
            {
                StockPerfomance = await _stockProcessor.CalculatePerfomanceAsync(defaultStockData.Concat(requestedStockData))
            };

            return result;
        }
    }
}
