using Ambev.DeveloperEvaluation.Application.Sales.Common;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

public class CreateSaleHandlerTests
{
    [Fact]
    public async Task Should_CreateSaleSuccessfully()
    {
        var repositoryMock = new Mock<ISaleRepository>();
        var loggerMock = new Mock<ILogger<CreateSaleHandler>>();
        var handler = new CreateSaleHandler(repositoryMock.Object, loggerMock.Object);

        var command = new CreateSaleCommand(Items: new List<SaleItemDto>
        {
            new SaleItemDto("Product A", 5, 100, 0.1m)
        });
        
        var result = await handler.Handle(command, CancellationToken.None);

        Assert.NotNull(result);
        repositoryMock.Verify(r => r.CreateAsync(It.IsAny<Sale>()), Times.Once);
        loggerMock.Verify(l => l.LogInformation(It.IsAny<string>(), It.IsAny<object[]>()), Times.Once);
    }
}
