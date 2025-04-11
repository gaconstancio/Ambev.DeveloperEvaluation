using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents an item in a sale.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class SaleItem : BaseEntity
{
    /// <summary>
    /// Gets the product name.
    /// </summary>
    public string Product { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the quantity of the product.
    /// </summary>
    public int Quantity { get; private set; }

    /// <summary>
    /// Gets the unit price of the product.
    /// </summary>
    public decimal UnitPrice { get; private set; }

    /// <summary>
    /// Gets the discount applied to the item.
    /// </summary>
    public decimal Discount { get; private set; }

    /// <summary>
    /// Gets the total amount of the item, considering quantity, unit price, and discount.
    /// </summary>
    public decimal TotalAmount => (UnitPrice * Quantity) - Discount;

    /// <summary>
    /// Initializes a new instance of the SaleItem class.
    /// </summary>
    public SaleItem() { }

    /// <summary>
    /// Initializes a new instance of the SaleItem class with required data.
    /// </summary>
    /// <param name="product">The product name.</param>
    /// <param name="quantity">The quantity of the product.</param>
    /// <param name="unitPrice">The unit price of the product.</param>
    /// <param name="discount">The discount applied to the item.</param>
    public SaleItem(string product, int quantity, decimal unitPrice, decimal discount)
    {
        Product = product;
        Quantity = quantity;
        UnitPrice = unitPrice;
        Discount = discount;
    }
}
