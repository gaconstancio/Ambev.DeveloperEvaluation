using Ambev.DeveloperEvaluation.Application.Sales.Common;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Represents the command to update an existing sale.
/// </summary>
/// <remarks>
/// This command contains the updated details of the sale and its items.
/// </remarks>
public record UpdateSaleCommand(Guid SaleId, List<SaleItemDto> Items) : IRequest<UpdateSaleResult>;

