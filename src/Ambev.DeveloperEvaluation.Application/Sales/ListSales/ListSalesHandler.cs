using System.Text.Json;
using Ambev.DeveloperEvaluation.Application.Common.Models;
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
            // Delegar toda a l�gica de filtragem, ordena��o e pagina��o ao reposit�rio
            var sales = await _saleRepository.GetPagedAndFilteredAsync(
                request.Page,
                request.Size,
                request.Order,
                request.Filter,
                request.MinTotalAmount,
                request.MaxTotalAmount,
                request.MinDate,
                request.MaxDate
            );

            var totalCount = await _saleRepository.GetTotalCountAsync();

            return new PaginatedResult<SaleDto>
            {
                Items = sales.ToList(),
                TotalCount = totalCount,
                Page = request.Page,
                Size = request.Size
            };
        }
        catch (Exception ex)
        {
            throw new ApplicationException(JsonSerializer.Serialize(new
            {
                type = "InternalServerError",
                error = "An error occurred while processing the request.",
                detail = ex.Message
            }));
        }
    }


}