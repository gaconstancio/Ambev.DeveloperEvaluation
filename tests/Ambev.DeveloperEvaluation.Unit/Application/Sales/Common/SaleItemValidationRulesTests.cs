using Ambev.DeveloperEvaluation.Application.Sales.Common;
using FluentValidation;
using FluentValidation.TestHelper;
using Xunit;

public class SaleItemValidationRulesTests
{
    private readonly InlineValidator<SaleItemDto> _validator;

    public SaleItemValidationRulesTests()
    {
        _validator = new InlineValidator<SaleItemDto>();
        SaleItemValidationRules.ApplyCommonRules(_validator);
    }

    [Fact]
    public void Should_HaveError_When_QuantityExceedsMaximum()
    {
        var saleItem = new SaleItemDto("Product A", 21, 100, 0);
        var result = _validator.TestValidate(saleItem);
        result.ShouldHaveValidationErrorFor(i => i.Quantity)
            .WithErrorMessage("The maximum quantity per item is 20.");
    }

    [Fact]
    public void Should_HaveError_When_DiscountIsInvalid()
    {
        var saleItem = new SaleItemDto("Product A", 5, 100, 0.2m);
        var result = _validator.TestValidate(saleItem);
        result.ShouldHaveValidationErrorFor(i => i.Discount)
            .WithErrorMessage("A 10% discount is required for quantities between 4 and 9.");
    }

    [Fact]
    public void Should_NotHaveError_When_ValidSaleItem()
    {
        var saleItem = new SaleItemDto("Product A", 5, 100, 0.1m);
        var result = _validator.TestValidate(saleItem);
        result.ShouldNotHaveAnyValidationErrors();
    }
}
