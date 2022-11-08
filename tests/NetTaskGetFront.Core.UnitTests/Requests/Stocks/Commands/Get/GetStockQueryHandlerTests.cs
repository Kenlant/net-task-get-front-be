using Moq;
using NetTaskGetFront.Core.Interfaces.Processors;
using NetTaskGetFront.Core.Interfaces.Repositories;
using NetTaskGetFront.Core.Interfaces.Services;
using NetTaskGetFront.Core.Requests.Stocks.Commands.Get;
using NetTaskGetFront.Domain.Entities;
using NetTaskGetFront.Domain.Enums;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NetTaskGetFront.Core.UnitTests.Requests.Stocks.Commands.Get
{
    [TestFixture]
    public class GetStockQueryHandlerTests
    {
        [Test]
        public async Task Handle_CorrectState_CallsAllServices()
        {
            var stockServiceMock = new Mock<IStockService>();
            var stockProcessorMock = new Mock<IStockProcessor>();
            var stockRepoMock = new Mock<IStockRepository>();
            var timeProviderMock = new Mock<ITimeProvider>();
            timeProviderMock.Setup(x => x.Now).Returns(DateTimeOffset.Now);
            var request = new GetStockQuery();
            var handler = new GetStockQueryHandler(stockServiceMock.Object,
                stockProcessorMock.Object, stockRepoMock.Object, timeProviderMock.Object);

            await handler.Handle(request, CancellationToken.None);

            stockServiceMock.Verify(x => x.GetAsync(It.IsAny<string>(), It.IsAny<TimePeriod>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>()), Times.Exactly(2));
            stockRepoMock.Verify(x => x.CreateBatchAsync(It.IsAny<IEnumerable<Stock>>(), It.IsAny<CancellationToken>()), Times.Once);
            stockProcessorMock.Verify(x => x.CalculatePerfomanceAsync(It.IsAny<IEnumerable<Stock>>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Test]
        public async Task Hadle_CorrectState_PassessCorrectParametersToStockService()
        {
            var endDate = DateTimeOffset.UtcNow;
            var startDate = endDate.AddDays(-7);
            var stockServiceMock = new Mock<IStockService>();
            var stockProcessorMock = new Mock<IStockProcessor>();
            var stockRepoMock = new Mock<IStockRepository>();

            var timeProviderMock = new Mock<ITimeProvider>();
            timeProviderMock.Setup(x => x.Now).Returns(endDate);

            var request = new GetStockQuery { Ticker = "test", Period = TimePeriod.Week };
            var handler = new GetStockQueryHandler(stockServiceMock.Object,
                stockProcessorMock.Object, stockRepoMock.Object, timeProviderMock.Object);

            await handler.Handle(request, CancellationToken.None);

            stockServiceMock.Verify(x => x.GetAsync(request.Ticker, request.Period, startDate, endDate));

        }
    }
}
