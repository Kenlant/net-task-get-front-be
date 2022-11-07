using NetTaskGetFront.Core.Infrastracture.Interfaces;

namespace NetTaskGetFront.Core.Requests.Test.Get
{
    public class GetTestDataQuery: IHandleableRequest<GetTestDataQuery, GetTestDataQueryHandler, GetTestDataViewModel>
    {
        public int BaseValue { get; set; }
    }
}
