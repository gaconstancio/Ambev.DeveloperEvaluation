using Ambev.DeveloperEvaluation.Application.Sales.Common;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Represents the command to create a new sale.
/// </summary>
/// <remarks>
/// This command contains the list of items to be included in the sale.
/// </remarks>
public record CreateSaleCommand(List<SaleItemDto> Items) : IRequest<CreateSaleResult>;

