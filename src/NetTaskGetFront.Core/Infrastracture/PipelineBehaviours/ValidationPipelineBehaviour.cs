using FluentValidation;
using MediatR;

namespace NetTaskGetFront.Core.Infrastracture.PipelineBehaviours
{
    public class ValidationPipelineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest: IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationPipelineBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var errors = _validators.SelectMany(x => x.Validate(context).Errors).ToList();

            if (errors.Any())
                throw new ValidationException(errors);

            return await next();
        }
    }
}
