using MediatR;

namespace NetTaskGetFront.Core.Requests.Test.Get
{
    public class GetTestDataQueryHandler : IRequestHandler<GetTestDataQuery, GetTestDataViewModel>
    {
        public async Task<GetTestDataViewModel> Handle(GetTestDataQuery request, CancellationToken cancellationToken)
        {
            return new GetTestDataViewModel
            {
                ValueOne = $"{request.BaseValue * 10}",
                ValueTwo = $"{request.BaseValue * 20}"
            };
        }
    }
}
