using FluentValidation;

namespace NetTaskGetFront.Core.Requests.Test.Get
{
    public class GetTestDataQueryValidator: AbstractValidator<GetTestDataQuery>
    {
        public GetTestDataQueryValidator()
        {
            RuleFor(x => x.BaseValue)
                .NotEmpty()
                .GreaterThan(2)
                .GreaterThan(3);
        }
    }
}
