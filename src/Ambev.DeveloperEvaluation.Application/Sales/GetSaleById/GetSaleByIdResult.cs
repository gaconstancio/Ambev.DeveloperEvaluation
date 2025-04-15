namespace Ambev.DeveloperEvaluation.Application.Sales.GetSaleById;

/// <summary>
/// Represents the result of retrieving a sale by its ID.
/// </summary>
public class GetSaleByIdResult
{
    public Guid Id { get; set; }
    public string SaleNumber { get; set; } = string.Empty;
    public DateTime SaleDate { get; set; }
    public string Customer { get; set; } = string.Empty;
    public string Branch { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public bool IsCancelled { get; set; }
}
