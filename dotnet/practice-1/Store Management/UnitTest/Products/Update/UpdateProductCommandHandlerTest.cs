using Application.Data;
using Application.Products.Create;
using Application.Products.Update;
using Domain.Products;
using Moq;

namespace UnitTest.Products.Update
{
    public class UpdateProductCommandHandlerTest
    {
        private readonly Mock<IProductRepository> _mockRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public UpdateProductCommandHandlerTest ()
        {
            _mockRepository = new();
            _unitOfWork = new();
        }

        [Fact]
        public async Task Handle_Should_RunOnce_WhenProductValid()
        {
            // Arrange
            ProductId productId = new ProductId(new Guid());
            var existedProduct = new Product(productId, "P1", new Money("USD", 1), Sku.Create("12121212")!);

            var command = new UpdateProductCommand(productId, "P1", "12121212", "USD", 1);

            var handler = new UpdateProductCommandHandler(_mockRepository.Object, _unitOfWork.Object);

            _mockRepository.Setup(
                x => x.GetByIdAsync(productId))
                .ReturnsAsync(existedProduct);

            // Act
            await handler.Handle(command, default);

            // Assert
            _unitOfWork.Verify(
                x => x.SaveChangesAsync(It.IsAny<CancellationToken>()),
                Times.Once);
        }
    }
}
