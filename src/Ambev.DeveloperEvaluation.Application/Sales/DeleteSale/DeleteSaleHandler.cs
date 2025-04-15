using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

/// <summary>
/// Handles the deletion of an existing sale.
/// </summary>
public class DeleteSaleHandler : IRequestHandler<DeleteSaleCommand, DeleteSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly ILogger<DeleteSaleHandler> _logger;
    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteSaleHandler"/> class.
    /// </summary>
    /// <param name="saleRepository">The repository used to delete the sale.</param>
    public DeleteSaleHandler(ISaleRepository saleRepository, ILogger<DeleteSaleHandler> logger)
    {
        _saleRepository = saleRepository;
        _logger = logger;
    }

    /// <summary>
    /// Handles the deletion of a sale.
    /// </summary>
    /// <param name="request">The command containing the sale ID to delete.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation, containing the result of the sale deletion.</returns>
    public async Task<DeleteSaleResult> Handle(DeleteSaleCommand request, CancellationToken cancellationToken)
    {
        var sale = await _saleRepository.GetByIdAsync(request.SaleId);
        if (sale == null)
        {
            throw new KeyNotFoundException($"The sale with ID {request.SaleId} was not found.");
        }

        await _saleRepository.DeleteAsync(new Domain.Entities.Sale() { Id = request.SaleId});

        // Log the SaleDeleted event with DateTime.Now
        _logger.LogInformation("SaleDeleted: Sale ID {SaleId} deleted at {CreatedAt} ",
            sale.Id, DateTime.Now);

        return new DeleteSaleResult
        {
            Success = true,
            Message = "Sale deleted successfully."
        };
    }
}
