using Car_Salon_App.Entities;
using FluentValidation;

namespace Car_Salon_App.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
        }
    }
}
