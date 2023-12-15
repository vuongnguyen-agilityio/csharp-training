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
        public async Task<IResult> CreateProduct([FromBody] CreateProductCommand command, ISender sender)
        {
            await sender.Send(command);

            return Results.Ok();
        }

        [HttpGet]
        public async Task<IResult> Get([FromQuery] ListProductQuery command, ISender sender)
        {
            return Results.Ok(await sender.Send(command));
        }

        [HttpGet("{id:guid}")]
        public async Task<IResult> GetById(Guid id, ISender sender)
        {
            return Results.Ok(await sender.Send(new GetProductQuery(new ProductId(id))));
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
            await sender.Send(new DeleteProductCommand(new ProductId(id)));

            return Results.NoContent();
        }
    }
}
