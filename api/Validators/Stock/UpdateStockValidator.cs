using api.DTOs.Stock;
using FluentValidation;

namespace api.Validators.Stock
{
    public class UpdateStockValidator : AbstractValidator<UpdateStockRequestDTO>
    {
        public UpdateStockValidator()
        {
            RuleFor(x => x.Symbol)
               .NotEmpty().WithMessage("Symbol is required.")
               .Length(1, 10).WithMessage("Symbol must be between 1 and 10 characters.");

            RuleFor(x => x.CompanyName)
                .NotEmpty().WithMessage("Company Name is required.")
                .Length(2, 100).WithMessage("Company Name must be between 2 and 100 characters.");

            RuleFor(x => x.Purchase)
                .GreaterThan(0).WithMessage("Purchase value must be greater than 0.")
                .InclusiveBetween(1, 1000000000).WithMessage("Purchase value must be between 1 and 1000000000.");

            RuleFor(x => x.LastDiv)
                .InclusiveBetween(0.001M, 100).WithMessage("LastDiv must be betwenn 0.001 and 100.");

            RuleFor(x => x.Industry)
                .NotEmpty().WithMessage("Industry is required.")
                .Length(2, 50).WithMessage("Industry must be between 2 and 50 characters.");

            RuleFor(x => x.MarketCap)
                .InclusiveBetween(1, 5000000000).WithMessage("MarketCap must be between 1 and 5000000000.");
        }
    }
}