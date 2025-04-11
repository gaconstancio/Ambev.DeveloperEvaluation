using Ambev.DeveloperEvaluation.Domain.DTOs;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of the <see cref="ISaleRepository"/> interface.
/// </summary>
public class SaleRepository : BaseRepository<Sale, ApplicationDbContext>, ISaleRepository
{
    public SaleRepository(ApplicationDbContext dbContext) : base(dbContext) { }

    /// <inheritdoc />
    public async Task<IEnumerable<SaleDto>> GetPagedAndFilteredAsync(int page, int size, string? order, string? filter)
    {
        var query = _dbContext.Sales.AsQueryable();

        // Apply filtering
        if (!string.IsNullOrEmpty(filter))
        {
            // Implement filtering logic here
        }

        // Apply ordering
        if (!string.IsNullOrEmpty(order))
        {
            // Implement ordering logic here
        }

        // Apply pagination
        query = query.Skip((page - 1) * size).Take(size);

        // Map to SaleDto
        return await query.Select(sale => new SaleDto
        {
            Id = sale.Id,
            SaleNumber = sale.SaleNumber,
            TotalAmount = sale.TotalAmount,
            IsCancelled = sale.IsCancelled
        }).ToListAsync();
    }

    /// <inheritdoc />
    public async Task<int> GetTotalCountAsync()
    {
        return await _dbContext.Sales.CountAsync();
    }
}
