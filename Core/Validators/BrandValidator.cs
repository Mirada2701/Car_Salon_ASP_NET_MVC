using Core.Dtos;
using Data.Entities;
using FluentValidation;

namespace Core.Validators
{
    public class BrandValidator : AbstractValidator<BrandDto>
    {
        public BrandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
        }       
    }
}
