using Data.Entities;
using FluentValidation;

namespace Core.Validators
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
        }       
    }
}
