using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a sale in the system.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class Sale : BaseEntity
{
    /// <summary>
    /// Gets the unique sale number.
    /// </summary>
    public string SaleNumber { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the date of the sale.
    /// </summary>
    public DateTime SaleDate { get; private set; }

    /// <summary>
    /// Gets the customer's name associated with the sale.
    /// </summary>
    public string Customer { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the branch where the sale was made.
    /// </summary>
    public string Branch { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the total amount of the sale.
    /// </summary>
    public decimal TotalAmount { get; private set; }

    /// <summary>
    /// Indicates whether the sale has been cancelled.
    /// </summary>
    public bool IsCancelled { get; private set; }

    /// <summary>
    /// Gets the collection of items associated with the sale.
    /// </summary>
    public ICollection<SaleItem> Items { get; private set; } = new List<SaleItem>();

    /// <summary>
    /// Initializes a new instance of the Sale class.
    /// </summary>
    public Sale() { }

    /// <summary>
    /// Initializes a new instance of the Sale class with required data.
    /// </summary>
    /// <param name="saleNumber">The unique sale number.</param>
    /// <param name="saleDate">The date of the sale.</param>
    /// <param name="customer">The customer's name.</param>
    /// <param name="branch">The branch where the sale was made.</param>
    /// <param name="totalAmount">The total amount of the sale.</param>
    public Sale(string saleNumber, DateTime saleDate, string customer, string branch, decimal totalAmount)
    {
        SaleNumber = saleNumber;
        SaleDate = saleDate;
        Customer = customer;
        Branch = branch;
        TotalAmount = totalAmount;
        IsCancelled = false;
    }

   
    /// <summary>
    /// Initializes a new instance of the Sale class with items and total amount.
    /// </summary>
    /// <param name="items">The collection of sale items.</param>
    /// <param name="totalAmount">The total amount of the sale.</param>
    public Sale(ICollection<SaleItem> items, decimal totalAmount)
    {
        Items = items;
        TotalAmount = totalAmount;
        SaleDate = DateTime.UtcNow; // Default to current date
        SaleNumber = Guid.NewGuid().ToString(); // Generate a unique sale number
        IsCancelled = false;
    }
    /// <summary>
    /// Adds an item to the sale.
    /// </summary>
    /// <param name="item">The sale item to add.</param>
    public void AddItem(SaleItem item)
    {
        Items.Add(item);
        RecalculateTotalAmount();
    }

    /// <summary>
    /// Cancels the sale.
    /// </summary>
    public void Cancel()
    {
        IsCancelled = true;
    }

    /// <summary>
    /// Recalculates the total amount of the sale based on the items.
    /// </summary>
    private void RecalculateTotalAmount()
    {
        TotalAmount = Items.Sum(item => item.TotalAmount);
    }
}
