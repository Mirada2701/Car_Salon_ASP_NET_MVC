﻿using Car_Salon_App.Dtos;
using FluentValidation;

namespace Car_Salon_App.Validators
{
    public class CarValidator : AbstractValidator<CarDto>
    {
        public CarValidator() 
        {
            RuleFor(x => x.BrandId).GreaterThan(0).WithMessage("Brand is required");
            RuleFor(x => x.Model).NotNull().NotEmpty();
            RuleFor(x => x.EngineId).GreaterThan(0).WithMessage("Engine is required");
            RuleFor(x => x.Price).GreaterThan(0);
            RuleFor(x => x.Discount).InclusiveBetween(0, 100);
            RuleFor(x => x.Quantity).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Description).MaximumLength(500);
            RuleFor(x => x.CategoryId).GreaterThan(0).WithMessage("Category is required");
            RuleFor(x => x.ImageUrl).NotNull().NotEmpty().Must(ValidateUri).WithMessage("Invalid URL");
        }
        public bool ValidateUri(string? uri)
        {
            if (string.IsNullOrEmpty(uri))
            {
                return true;
            }
            return Uri.TryCreate(uri, UriKind.Absolute, out _);
        }
    }
}
