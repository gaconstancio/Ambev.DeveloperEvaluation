using Ambev.DeveloperEvaluation.Application.Sales.Common;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using FluentValidation.TestHelper;
using Xunit;

public class UpdateSaleValidatorTests
{
    private readonly UpdateSaleValidator _validator;

    public UpdateSaleValidatorTests()
    {
        _validator = new UpdateSaleValidator();
    }

    [Fact]
    public void Should_HaveError_When_SaleIdIsEmpty()
    {
        var command = new UpdateSaleCommand(Guid.Empty, new List<SaleItemDto>());
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(c => c.SaleId)
            .WithErrorMessage("The sale ID is required.");
    }

    [Fact]
    public void Should_NotHaveError_When_ValidCommand()
    {
        var command = new UpdateSaleCommand(
            Guid.NewGuid(),
            new List<SaleItemDto>
            {
                new SaleItemDto("Product A", 5, 100, 0.1m)
            }
        );
        var result = _validator.TestValidate(command);
        result.ShouldNotHaveAnyValidationErrors();
    }
}
