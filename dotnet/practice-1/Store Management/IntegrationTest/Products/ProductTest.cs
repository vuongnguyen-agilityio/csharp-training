using Application.Exceptions;
using Application.Products.Create;
using Application.Products.Delete;
using Application.Products.Get;
using Application.Products.Update;
using Domain.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static WebApi.Exceptions.ExceptionHandler;

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
            string jsonValue = JsonConvert.SerializeObject(new
            {
                Name = "P1",
                Sku = "12121212",
                Currency = "USD",
                Amount = "1"
            });
            StringContent content = new StringContent(jsonValue, Encoding.UTF8, "application/json");

            // Act
            var result = await Client.PostAsync("/product", content);

            // Assert

            var product = DbContext.Products.FirstOrDefault();

            Assert.Equal(200, (int)result.StatusCode);
            Assert.NotNull(product);
            Assert.Equal("P1", product.Name);
        }

        [Fact]
        public async Task Create_Should_Throw_ValidationException_WhenSkuIsInvalid()
        {
            // Arrange
            string jsonValue = JsonConvert.SerializeObject(new
            {
                Name = "P1",
                Sku = "12121212",
                Currency = "USD",
                Amount = "1"
            });
            StringContent content = new StringContent(jsonValue, Encoding.UTF8, "application/json");

            await Client.PostAsync("/product", content);

            // Act
            var result = await Client.PostAsync("/product", content);

            ExceptionDetails err = await result.Content.ReadFromJsonAsync<ExceptionDetails>();
            
            // Assert
            Assert.Equal(400, (int)result.StatusCode);
        }


        [Fact]
        public async Task Get_Should_Return_ProductById()
        {
            var command = new CreateProductCommand("P1", "12121212", "USD", 1);
            await Sender.Send(command);

            var product = DbContext.Products.First();


            var result = await Client.GetAsync($"/product/{product.Id.Value}");

            ProductResponse productRes = await result.Content.ReadFromJsonAsync<ProductResponse>();

            Assert.NotNull(productRes);
            Assert.Equal("P1", productRes.Name);
            Assert.Equal("12121212", productRes.Sku);
            Assert.Equal("USD", productRes.Currency);
            Assert.Equal(1, productRes.Amount);
        }

        [Fact]
        public async Task Update_Should_Update_ProductToDatabase()
        {
            var command = new CreateProductCommand("P1", "12121212", "USD", 1);
            await Sender.Send(command);
            var product = DbContext.Products.First();

            string jsonValue = JsonConvert.SerializeObject(new
            {
                Name = "P1 Updated",
                Sku = "12121213",
                Currency = "VND",
                Amount = 10000
            });
            StringContent content = new StringContent(jsonValue, Encoding.UTF8, "application/json");
            var result = await Client.PutAsync($"/product/{product.Id.Value}", content);
            var updatedProduct = DbContext.Products.First();

            Assert.Equal(204, (int)result.StatusCode);
            Assert.Equal(product.Id.Value, updatedProduct.Id.Value);
        }

        [Fact]
        public async Task Delete_Should_Remove_ProductFromDatabase()
        {
            var command = new CreateProductCommand("P1", "12121212", "USD", 1);
            await Sender.Send(command);

            var product = DbContext.Products.First();

            var result = await Client.DeleteAsync($"/product/{product.Id.Value}");

            var existedproduct = DbContext.Products.FirstOrDefault();

            Assert.Null(existedproduct);
        }
    }
}
