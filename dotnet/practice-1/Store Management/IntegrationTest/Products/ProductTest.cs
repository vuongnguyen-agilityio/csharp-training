using Application.Exceptions;
using Application.Products.Create;
using Application.Products.Delete;
using Application.Products.Get;
using Application.Products.Update;
using Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace IntegrationTest.Products
{
    public class ProductTest : BaseIntegrationTest, IDisposable
    {
        public ProductTest(IntegrationTestWebFactory webFactory) : base(webFactory)
        {
        }

        public void Dispose()
        {
            //Do cleanup actions here
            this.DbContext.Products.ExecuteDeleteAsync();
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
            var command = new CreateProductCommand("P1", "12121212", "USD", 1);
            await Sender.Send(command);

            // Arrange
            var commandDuplicateSku = new CreateProductCommand("P1", "12121212", "USD", 1);

            // Act
            Task Action() => Sender.Send(commandDuplicateSku);

            // Assert
            await Assert.ThrowsAsync<ValidationException>(Action);
        }


        [Fact]
        public async Task Get_Should_Return_ProductById()
        {
            var command = new CreateProductCommand("P1", "12121212", "USD", 1);
            await Sender.Send(command);

            var product = DbContext.Products.First();

            var productById = await Sender.Send(new GetProductQuery(product.Id));

            Assert.NotNull(productById);
            Assert.Equal(product.Id.Value, productById.Id);
        }

        [Fact]
        public async Task Update_Should_Update_ProductToDatabase()
        {
            var command = new CreateProductCommand("P1", "12121212", "USD", 1);
            await Sender.Send(command);

            var product = DbContext.Products.First();
            var updateCommand = new UpdateProductCommand(
                product.Id,
                "P1 Updated",
                "12121213",
                "VND",
                10000);
            await Sender.Send(updateCommand);

            var updatedProduct = DbContext.Products.First();

            Assert.Equal(product.Id.Value, updatedProduct.Id.Value);
            Assert.Equal("P1 Updated", updatedProduct.Name);
            Assert.Equal(updatedProduct.Sku, Sku.Create("12121213"));
            Assert.Equal(updatedProduct.Price, new Money("VND", 10000));
        }

        [Fact]
        public async Task Delete_Should_Remove_ProductFromDatabase()
        {
            var command = new CreateProductCommand("P1", "12121212", "USD", 1);
            await Sender.Send(command);

            var product = DbContext.Products.First();

            await Sender.Send(new DeleteProductCommand(product.Id));

            var existedproduct = DbContext.Products.FirstOrDefault();

            Assert.Null(existedproduct);
        }
    }
}
