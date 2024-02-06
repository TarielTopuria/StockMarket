using FluentValidation;

namespace api.Validators
{
    public class IdValidator : AbstractValidator<int>
    {
        public IdValidator()
        {
            RuleFor(id => id)
               .GreaterThanOrEqualTo(1).WithMessage("ID must be greater than or equal to 1");
        }
    }
}
