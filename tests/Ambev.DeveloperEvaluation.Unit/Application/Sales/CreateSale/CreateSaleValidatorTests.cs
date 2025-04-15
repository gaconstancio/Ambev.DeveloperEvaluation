using Ambev.DeveloperEvaluation.Application.Sales.Common;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using FluentValidation.TestHelper;
using Xunit;

public class CreateSaleValidatorTests
{
    private readonly CreateSaleValidator _validator;

    public CreateSaleValidatorTests()
    {
        _validator = new CreateSaleValidator();
    }

    [Fact]
    public void Should_HaveError_When_ItemsAreEmpty()
    {
        var command = new CreateSaleCommand(new List<SaleItemDto>());
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(c => c.Items)
            .WithErrorMessage("The item list cannot be empty.");
    }

    [Fact]
    public void Should_NotHaveError_When_ValidCommand()
    {
        var command = new CreateSaleCommand(new List<SaleItemDto>
            {
                new SaleItemDto("Product A", 5, 100, 0.1m)
            });

        var result = _validator.TestValidate(command);
        result.ShouldNotHaveAnyValidationErrors();
    }
}
