using System.Linq.Dynamic.Core;
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

    public async Task<IEnumerable<SaleDto>> GetPagedAndFilteredAsync(
     int page,
     int size,
     string? order,
     string? filter,
     decimal? minTotalAmount = null,
     decimal? maxTotalAmount = null,
     DateTime? minDate = null,
     DateTime? maxDate = null)
    {
        var query = _dbContext.Sales.AsQueryable();

        // Apply filtering
        if (!string.IsNullOrEmpty(filter))
        {
            query = query.Where(s => EF.Functions.Like(s.SaleNumber, $"%{filter}%"));
        }

        if (minTotalAmount.HasValue)
        {
            query = query.Where(s => s.TotalAmount >= minTotalAmount.Value);
        }

        if (maxTotalAmount.HasValue)
        {
            query = query.Where(s => s.TotalAmount <= maxTotalAmount.Value);
        }

        if (minDate.HasValue)
        {
            query = query.Where(s => s.SaleDate >= minDate.Value);
        }

        if (maxDate.HasValue)
        {
            query = query.Where(s => s.SaleDate <= maxDate.Value);
        }

        // Validate and apply ordering
        var allowedOrderFields = new[] { "SaleDate", "TotalAmount" };
        if (!string.IsNullOrEmpty(order) && allowedOrderFields.Contains(order.Split(' ')[0]))
        {
            query = query.OrderBy(order);
        }

        // Apply pagination
        query = query.Skip((page - 1) * size).Take(size);

        // Map to SaleDto
        return await query.Select(sale => new SaleDto
        {
            Id = sale.Id,
            SaleNumber = sale.SaleNumber,
            TotalAmount = sale.TotalAmount,
            IsCancelled = sale.IsCancelled,
            SaleDate = sale.SaleDate
        }).ToListAsync();
    }




    public async Task<int> GetTotalCountAsync()
    {
        return await _dbContext.Sales.CountAsync();
    }
}
