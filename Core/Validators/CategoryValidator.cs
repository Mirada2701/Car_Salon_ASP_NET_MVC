using Core.Dtos;
using Data.Entities;
using FluentValidation;

namespace Core.Validators
{
    public class CategoryValidator : AbstractValidator<CategoryDto>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
        }
    }
}
