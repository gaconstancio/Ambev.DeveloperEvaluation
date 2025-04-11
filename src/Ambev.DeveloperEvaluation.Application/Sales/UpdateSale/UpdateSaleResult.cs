namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Represents the result of a successful sale update.
/// </summary>
/// <remarks>
/// This result contains the unique identifier, sale number, and total amount of the updated sale.
/// </remarks>
public record UpdateSaleResult
{
    /// <summary>
    /// Gets the unique identifier of the updated sale.
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
    /// Initializes a new instance of the <see cref="UpdateSaleResult"/> class.
    /// </summary>
    /// <param name="id">The unique identifier of the sale.</param>
    /// <param name="saleNumber">The sale number.</param>
    /// <param name="totalAmount">The total amount of the sale.</param>
    public UpdateSaleResult(Guid id, string saleNumber, decimal totalAmount)
    {
        Id = id;
        SaleNumber = saleNumber;
        TotalAmount = totalAmount;
    }
}
