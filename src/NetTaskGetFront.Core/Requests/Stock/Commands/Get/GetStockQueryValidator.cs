﻿using FluentValidation;

namespace NetTaskGetFront.Core.Requests.Stock.Commands.Get
{
    public class GetStockQueryValidator: AbstractValidator<GetStockQuery>
    {
        public GetStockQueryValidator()
        {
            RuleFor(x => x.Ticker)
                .NotEmpty();
            RuleFor(x => x.Period)
                .IsInEnum();
        }
    }
}
