   namespace Ambev.DeveloperEvaluation.Application.Sales.Common;

   /// <summary>
   /// Represents an item in a sale.
   /// </summary>
   /// <param name="Product">The name of the product.</param>
   /// <param name="Quantity">The quantity of the product.</param>
   /// <param name="UnitPrice">The unit price of the product.</param>
   public record SaleItemDto(string Product, int Quantity, decimal UnitPrice);
   