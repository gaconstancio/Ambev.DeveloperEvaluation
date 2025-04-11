using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

/// <summary>
/// Validates the <see cref="DeleteSaleCommand"/> using FluentValidation.
/// </summary>
public class DeleteSaleValidator : AbstractValidator<DeleteSaleCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteSaleValidator"/> class.
    /// </summary>
    public DeleteSaleValidator()
    {
        RuleFor(x => x.SaleId)
            .NotEmpty().WithMessage("The sale ID is required.");
    }
}
