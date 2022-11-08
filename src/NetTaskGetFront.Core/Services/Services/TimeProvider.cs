using NetTaskGetFront.Core.Interfaces.Services;

namespace NetTaskGetFront.Core.Services.Services
{
    public class TimeProvider : ITimeProvider
    {
        public DateTimeOffset Now => DateTimeOffset.Now;
    }
}
