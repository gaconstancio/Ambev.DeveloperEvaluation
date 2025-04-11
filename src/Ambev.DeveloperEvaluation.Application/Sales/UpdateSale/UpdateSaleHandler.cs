namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Handles the update of an existing sale.
/// </summary>
/// <remarks>
/// This handler retrieves the existing sale, updates its properties, reapplies discount rules, and persists the changes.
/// </remarks>
public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
{
    private readonly ISaleRepository _saleRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateSaleHandler"/> class.
    /// </summary>
    /// <param name="saleRepository">The repository used to retrieve and persist the sale.</param>
    public UpdateSaleHandler(ISaleRepository saleRepository)
    {
        _saleRepository = saleRepository;
    }

    /// <summary>
    /// Handles the update of a sale.
    /// </summary>
    /// <param name="request">The command containing the updated sale details.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation, containing the result of the sale update.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the total quantity of any item exceeds 20.</exception>
    public async Task<UpdateSaleResult> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
    {
        // Retrieve the existing sale
        var sale = await _saleRepository.GetByIdAsync(request.SaleId);
        if (sale == null)
        {
            throw new KeyNotFoundException("The sale with the specified ID was not found.");
        }

        // Update sale items and apply discount rules
        var updatedItems = request.Items.Select(item =>
        {
            if (item.Quantity > 20)
            {
                throw new InvalidOperationException("The quantity of an item cannot exceed 20.");
            }

            decimal discount = item.Quantity switch
            {
                >= 4 and <= 9 => item.UnitPrice * item.Quantity * 0.10m,
                >= 10 and <= 20 => item.UnitPrice * item.Quantity * 0.20m,
                _ => 0m
            };

            return new SaleItem(item.Product, item.Quantity, item.UnitPrice, discount);
        }).ToList();

        // Update sale properties
        sale.UpdateItems(updatedItems);
        sale.RecalculateTotalAmount();

        // Persist the updated sale
        await _saleRepository.UpdateAsync(sale);

        // Return the result
        return new UpdateSaleResult(sale.Id, sale.SaleNumber, sale.TotalAmount);
    }
}
