namespace Ambev.DeveloperEvaluation.Application.Common.Models;

/// <summary>
/// Represents a paginated result for list endpoints.
/// </summary>
/// <typeparam name="T">The type of the items in the result.</typeparam>
public class PaginatedResult<T>
{
    /// <summary>
    /// Gets or sets the items in the current page.
    /// </summary>
    public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();

    /// <summary>
    /// Gets or sets the total count of items.
    /// </summary>
    public int TotalCount { get; set; }

    /// <summary>
    /// Gets or sets the current page number.
    /// </summary>
    public int Page { get; set; }

    /// <summary>
    /// Gets or sets the size of the page.
    /// </summary>
    public int Size { get; set; }
}
