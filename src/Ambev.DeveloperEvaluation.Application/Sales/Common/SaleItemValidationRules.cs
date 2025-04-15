using Ambev.DeveloperEvaluation.Application.Sales.Common;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
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

        // Discount rules based on quantity
        validator.RuleFor(i => i)
            .Must(i => i.Quantity < 4 || i.Discount == 0)
            .WithMessage("No discounts are allowed for less than 4 items.");

        validator.RuleFor(i => i)
            .Must(i => i.Quantity >= 4 && i.Quantity <= 9 && i.Discount == 0.1m || i.Quantity < 4)
            .WithMessage("A 10% discount is required for quantities between 4 and 9.");

        validator.RuleFor(i => i)
            .Must(i => i.Quantity >= 10 && i.Quantity <= 20 && i.Discount == 0.2m || i.Quantity < 10)
            .WithMessage("A 20% discount is required for quantities between 10 and 20.");

    }

    public static void ApplyTotalQuantityRule<T>(AbstractValidator<T> validator, Func<T, IEnumerable<SaleItemDto>> itemsSelector)
    {
        validator.RuleFor(command => itemsSelector(command).Sum(i => i.Quantity))
            .LessThanOrEqualTo(20).WithMessage("The total quantity of items in the sale cannot exceed 20.");
    }

}

