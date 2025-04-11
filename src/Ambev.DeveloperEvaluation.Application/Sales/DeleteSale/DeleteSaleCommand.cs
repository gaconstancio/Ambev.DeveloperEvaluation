namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

/// <summary>
/// Command for deleting an existing sale.
/// </summary>
/// <remarks>
/// This command contains the unique identifier of the sale to be deleted.
/// </remarks>
public record DeleteSaleCommand(Guid SaleId) : IRequest<DeleteSaleResult>;
