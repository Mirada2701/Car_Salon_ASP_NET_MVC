using Core.Dtos;
using Data.Entities;
using FluentValidation;

namespace Core.Validators
{
    public class EngineValidator : AbstractValidator<EngineDto>
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
