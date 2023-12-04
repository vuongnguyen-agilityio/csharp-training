using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MediatR;

using Domain.Products;
using Application.Products.Create;
using Application.Products.Delete;
using Application.Products.Get;
using Application.Products.List;
using Application.Products.Update;
using Domain.Users;

namespace Web.API.Endpoints
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        [Authorize(Roles = nameof(UserRole.Admin))]
        [HttpPost]
        public async Task<IResult> CreateProduct(CreateProductCommand command, ISender sender)
        {
            await sender.Send(command);

            return Results.Ok();
        }

        [HttpGet(Name = "GetProduct")]
        public async Task<IResult> Get(ISender sender)
        {
            return Results.Ok(await sender.Send(new ListProductQuery()));
        }

        [HttpGet("{id:guid}")]
        public async Task<IResult> GetById(Guid id, ISender sender)
        {
            try
            {
                return Results.Ok(await sender.Send(new GetProductQuery(new ProductId(id))));
            }
            catch (ProductNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        }

        [Authorize(Roles = nameof(UserRole.Admin))]
        [HttpPut("{id:guid}")]
        public async Task<IResult> UpdateById(Guid id, [FromBody] UpdateProductRequest request, ISender sender)
        {
            var command = new UpdateProductCommand(
                new ProductId(id),
                request.Name,
                request.Sku,
                request.Currency,
                request.Amount);

            await sender.Send(command);

            return Results.NoContent();
        }

        [Authorize(Roles = nameof(UserRole.Admin))]
        [HttpDelete("{id:guid}")]
        public async Task<IResult> DeleteById(Guid id, ISender sender)
        {
            try
            {
                await sender.Send(new DeleteProductCommand(new ProductId(id)));

                return Results.NoContent();
            }
            catch (ProductNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        }
    }
}
