using MediatR;

namespace NetTaskGetFront.Core.Infrastracture.Interfaces
{
    public interface IHandleableRequest<TRequest, THandler, TResponse> : IRequest<TResponse>
        where TRequest: IRequest<TResponse>
        where THandler: IRequestHandler<TRequest, TResponse>
    {
    }

    public interface IHandleableRequest<TRequest, THandler>: IRequest
        where TRequest : IRequest
        where THandler : IRequestHandler<TRequest>
    {
    }
}
