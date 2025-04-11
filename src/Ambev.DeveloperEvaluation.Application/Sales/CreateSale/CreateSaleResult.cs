namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Represents the result of a successful sale creation.
/// </summary>
/// <remarks>
/// This result contains the unique identifier, sale number, and total amount of the created sale.
/// </remarks>
public record CreateSaleResult
{
    /// <summary>
    /// Gets the unique identifier of the created sale.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Gets the automatically generated sale number.
    /// </summary>
    public string SaleNumber { get; init; }

    /// <summary>
    /// Gets the total amount of the sale, including applied discounts.
    /// </summary>
    public decimal TotalAmount { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateSaleResult"/> class.
    /// </summary>
    /// <param name="id">The unique identifier of the sale.</param>
    /// <param name="saleNumber">The sale number.</param>
    /// <param name="totalAmount">The total amount of the sale.</param>
    public CreateSaleResult(Guid id, string saleNumber, decimal totalAmount)
    {
        Id = id;
        SaleNumber = saleNumber;
        TotalAmount = totalAmount;
    }
}
