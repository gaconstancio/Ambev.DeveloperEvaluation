using Ambev.DeveloperEvaluation.Application.Sales.Common;
using FluentValidation;

public static class SaleItemValidationRules
{
    public static void ApplyCommonRules(AbstractValidator<SaleItemDto> validator)
    {
        validator.RuleFor(i => i.Product)
            .NotEmpty().WithMessage("The product name is required.");

        validator.RuleFor(i => i.Quantity)
            .GreaterThan(0).WithMessage("The quantity must be greater than zero.")
            .LessThanOrEqualTo(20).WithMessage("The maximum quantity per item is 20.");

        validator.RuleFor(i => i.UnitPrice)
            .GreaterThan(0).WithMessage("The unit price must be greater than zero.");

        // New Rule: No discounts for items with less than 4 units
        validator.RuleFor(i => i.Quantity)
            .Must(q => q < 4 ).WithMessage("Discounts are not allowed for less than 4 items.");
    }
}
