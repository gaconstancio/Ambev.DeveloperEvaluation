using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSaleById;

/// <summary>
/// Query to retrieve a sale by its ID.
/// </summary>
public class GetSaleByIdQuery : IRequest<GetSaleByIdResult>
{
    /// <summary>
    /// The ID of the sale to retrieve.
    /// </summary>
    public Guid Id { get; set; }
}
