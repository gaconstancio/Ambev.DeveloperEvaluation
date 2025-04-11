using Ambev.DeveloperEvaluation.Domain.DTOs;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Interface for accessing sales data.
/// </summary>
public interface ISaleRepository : IBaseRepository<Sale>
{
    /// <summary>
    /// Retrieves a paginated and filtered list of sales.
    /// </summary>
    /// <param name="page">The page number.</param>
    /// <param name="size">The size of the page.</param>
    /// <param name="order">The ordering criteria.</param>
    /// <param name="filter">The filtering criteria.</param>
    /// <returns>A list of sales matching the criteria.</returns>
    Task<IEnumerable<SaleDto>> GetPagedAndFilteredAsync(int page, int size, string? order, string? filter);

    /// <summary>
    /// Retrieves the total count of sales.
    /// </summary>
    /// <returns>The total count of sales.</returns>
    Task<int> GetTotalCountAsync();
}
