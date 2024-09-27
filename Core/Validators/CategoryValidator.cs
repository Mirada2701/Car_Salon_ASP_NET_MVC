using Data.Entities;
using FluentValidation;

namespace Core.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
        }
    }
}
