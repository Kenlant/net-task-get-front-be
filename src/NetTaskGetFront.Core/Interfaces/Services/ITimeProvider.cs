namespace NetTaskGetFront.Core.Interfaces.Services
{
    public interface ITimeProvider
    {
        DateTimeOffset Now { get; }
    }
}
