using Application.Data;
using Application.Products.Update;
using Domain.Products;
using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Moq;

namespace UnitTest.Products.Update
{
    public class UpdateProductCommandValidatorTest
    {
        private readonly Mock<IProductRepository> _mockRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public UpdateProductCommandValidatorTest()
        {
            _mockRepository = new();
            _unitOfWork = new();
        }

        [Fact]
        public async void Validator_Should_ReturnFailure_WhenSkuIsExisted()
        {
            // Arrange
            var command = new UpdateProductRequest("P1", "12121212", "USD", 1);

            _mockRepository.Setup(
                x => x.IsSkuUniqueAsync(
                    It.IsAny<Sku>()))
                .ReturnsAsync(false);

            var handler = new UpdateProductCommandValidator(_mockRepository.Object);

            // Act
            ValidationResult result = await handler.TestValidateAsync(command);

            // Assert
            result.Errors.Where(e => e.PropertyName == "Sku").ToList().Count().Equals(1);
            result.Errors.Where(e => e.PropertyName == "Sku").ToList()[0].PropertyName.Should().Be("Sku");
            result.Errors.Where(e => e.PropertyName == "Sku").ToList()[0].ErrorMessage.Should().Be("The sku must be unique");
        }
    }
}
