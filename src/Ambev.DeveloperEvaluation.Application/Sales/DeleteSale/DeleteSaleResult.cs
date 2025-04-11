namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

/// <summary>
/// Represents the result of a successful sale deletion.
/// </summary>
public record DeleteSaleResult
{
    /// <summary>
    /// Indicates whether the deletion was successful.
    /// </summary>
    public bool Success { get; init; }

    /// <summary>
    /// Provides a message about the result of the deletion.
    /// </summary>
    public string Message { get; init; }
}
