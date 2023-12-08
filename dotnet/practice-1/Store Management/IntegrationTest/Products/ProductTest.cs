using Application.Exceptions;
using Application.Products.Create;

namespace IntegrationTest.Products
{
    public class ProductTest : BaseIntegrationTest
    {
        public ProductTest(IntegrationTestWebFactory webFactory) : base(webFactory)
        {
            webFactory.DisposeAsync();
            webFactory.InitializeAsync();
        }

        [Fact]
        public async Task Create_Should_Add_NewProductToDatabase()
        {

            // Arrange
            var command = new CreateProductCommand("P1", "12121212", "USD", 1);

            // Act
            await Sender.Send(command);

            // Assert

            var product = DbContext.Products.First();

            Assert.NotNull(product);
            Assert.Equal("P1", product.Name);
        }

        [Fact]
        public async Task Create_Should_Throw_ValidationException_WhenSkuIsInvalid()
        {
            // Arrange
            var commandDuplicateSku = new CreateProductCommand("P1", "12121212", "USD", 1);

            // Act
            Task Action() => Sender.Send(commandDuplicateSku);

            // Assert
            await Assert.ThrowsAsync<ValidationException>(Action);
        }
    }
}
