using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Validates the <see cref="UpdateSaleCommand"/> using FluentValidation.
/// </summary>
/// <remarks>
/// Ensures that all fields in the command meet the required business rules.
/// </remarks>
public class UpdateSaleValidator : AbstractValidator<UpdateSaleCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateSaleValidator"/> class.
    /// </summary>
    public UpdateSaleValidator()
    {
        RuleForEach(x => x.Items).ChildRules(item =>
        {
            SaleItemValidationRules.ApplyCommonRules(item);
        });
        
        RuleFor(x => x.Items)
            .NotEmpty().WithMessage("The item list cannot be empty.");

        RuleFor(x => x.SaleId)
            .NotEmpty().WithMessage("The sale ID is required.");

        SaleItemValidationRules.ApplyTotalQuantityRule(this, x => x.Items);
    }
}

