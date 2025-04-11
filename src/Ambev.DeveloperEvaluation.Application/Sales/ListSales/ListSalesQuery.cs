using Ambev.DeveloperEvaluation.Application.Common.Models;
using Ambev.DeveloperEvaluation.Domain.DTOs;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSales;

/// <summary>
/// Query for listing sales with pagination, ordering, and filtering.
/// </summary>
public class ListSalesQuery : IRequest<PaginatedResult<SaleDto>>
{
    /// <summary>
    /// Gets or sets the page number.
    /// </summary>
    public int Page { get; set; } = 1;

    /// <summary>
    /// Gets or sets the page size.
    /// </summary>
    public int Size { get; set; } = 10;

    /// <summary>
    /// Gets or sets the ordering criteria.
    /// </summary>
    public string? Order { get; set; }

    /// <summary>
    /// Gets or sets the filtering criteria.
    /// </summary>
    public string? Filter { get; set; }
}
