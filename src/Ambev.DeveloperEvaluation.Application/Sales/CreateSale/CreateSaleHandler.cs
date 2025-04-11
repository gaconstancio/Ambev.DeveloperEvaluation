using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Handles the creation of a new sale.
/// </summary>
/// <remarks>
/// This handler applies business rules, calculates discounts, and persists the sale using the repository.
/// </remarks>
public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly ISaleRepository _saleRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateSaleHandler"/> class.
    /// </summary>
    /// <param name="saleRepository">The repository used to persist the sale.</param>
    public CreateSaleHandler(ISaleRepository saleRepository)
    {
        _saleRepository = saleRepository;
    }

    /// <summary>
    /// Handles the creation of a sale.
    /// </summary>
    /// <param name="request">The command containing the sale details.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation, containing the result of the sale creation.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the total quantity of items exceeds 20.</exception>
    public async Task<CreateSaleResult> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
    {
        var saleItems = request.Items.Select(item =>
        {
            decimal discount = item.Quantity switch
            {
                >= 4 and <= 9 => item.UnitPrice * item.Quantity * 0.10m,
                >= 10 and <= 20 => item.UnitPrice * item.Quantity * 0.20m,
                _ => 0m
            };

            return new SaleItem(item.Product, item.Quantity, item.UnitPrice, discount);
        }).ToList();

        var totalAmount = saleItems.Sum(i => i.TotalAmount);

        var sale = new Sale(saleItems, totalAmount);
        await _saleRepository.CreateAsync(sale);

        return new CreateSaleResult(sale.Id, sale.SaleNumber, sale.TotalAmount);
    }
}
