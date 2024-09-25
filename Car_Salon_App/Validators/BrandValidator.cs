using Car_Salon_App.Entities;
using FluentValidation;

namespace Car_Salon_App.Validators
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
        }       
    }
}
