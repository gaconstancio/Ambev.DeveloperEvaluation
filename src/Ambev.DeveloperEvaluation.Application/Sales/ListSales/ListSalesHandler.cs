using System.Text.Json;
using Ambev.DeveloperEvaluation.Application.Common.Models;
using Ambev.DeveloperEvaluation.Application.Sales.ListSales;
using Ambev.DeveloperEvaluation.Domain.DTOs;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

public class ListSalesHandler : IRequestHandler<ListSalesQuery, PaginatedResult<SaleDto>>
{
    private readonly ISaleRepository _saleRepository;

    public ListSalesHandler(ISaleRepository saleRepository)
    {
        _saleRepository = saleRepository;
    }

    public async Task<PaginatedResult<SaleDto>> Handle(ListSalesQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var sales = await _saleRepository.GetPagedAndFilteredAsync(request.Page, request.Size, request.Order, request.Filter);
            var totalCount = await _saleRepository.GetTotalCountAsync();

            return new PaginatedResult<SaleDto>
            {
                Items = sales,
                TotalCount = totalCount,
                Page = request.Page,
                Size = request.Size
            };
        }
        catch (Exception ex)
        {
            // Log the exception (if logging is configured)
            // Return a formatted error response
            throw new ApplicationException(JsonSerializer.Serialize(new
            {
                type = "InternalServerError",
                error = "An error occurred while processing the request.",
                detail = ex.Message
            }));
        }
    }
}