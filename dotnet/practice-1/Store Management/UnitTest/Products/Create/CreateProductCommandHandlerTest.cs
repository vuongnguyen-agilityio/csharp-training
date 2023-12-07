using Application.Data;
using Application.Products.Create;
using Domain.Products;
using Moq;

namespace UnitTest.Products.Commands
{
    public class CreateProductCommandHandlerTest
    {
        private readonly Mock<IProductRepository> _mockRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public CreateProductCommandHandlerTest ()
        {
            _mockRepository = new();
            _unitOfWork = new();
        }

        [Fact]
        public async Task Handle_Should_RunOnce_WhenProductValid()
        {
            // Arrange
            var command = new CreateProductCommand("P1", "12121212", "USD", 1);

            var handler = new CreateProductCommandHandler(_mockRepository.Object, _unitOfWork.Object);

            // Act
            await handler.Handle(command, default);

            // Assert
            _unitOfWork.Verify(
                x => x.SaveChangesAsync(It.IsAny<CancellationToken>()),
                Times.Once);
        }
    }
}
