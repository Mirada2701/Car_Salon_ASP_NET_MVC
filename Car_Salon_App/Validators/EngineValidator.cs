using Car_Salon_App.Entities;
using FluentValidation;

namespace Car_Salon_App.Validators
{
    public class EngineValidator : AbstractValidator<Engine>
    {
        public EngineValidator() 
        {
            RuleFor(x => x.Capacity).InclusiveBetween(0,10);
            RuleFor(x => x.Type).Must(ValidateFuelType).WithMessage("Wrong fuel type");
        }
        public bool ValidateFuelType(string type)
        {
            return type == "Petrol" || type == "Diesel";
        }
    }
}
