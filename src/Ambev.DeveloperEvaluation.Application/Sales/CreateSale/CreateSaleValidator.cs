using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Validates the <see cref="CreateSaleCommand"/> using FluentValidation.
/// </summary>
/// <remarks>
/// Ensures that all fields in the command meet the required business rules.
/// </remarks>
public class CreateSaleValidator : AbstractValidator<CreateSaleCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateSaleValidator"/> class.
    /// </summary>
    public CreateSaleValidator()
    {
        RuleForEach(x => x.Items).ChildRules(item =>
        {
            SaleItemValidationRules.ApplyCommonRules(item);
        });

        RuleFor(x => x.Items)
            .NotEmpty().WithMessage("The item list cannot be empty.");
    }
}

