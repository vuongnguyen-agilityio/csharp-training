using Microsoft.AspNetCore.Mvc;
using MediatR;

using Domain.Carts;
using Domain.Products;
using Domain.Users;
using Application.Carts.Create;
using Application.Carts.Delete;
using Application.Carts.List;
using Application.Carts.Update;

namespace Web.API.Endpoints
{
    [ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase
    {
        [HttpPost]
        public async Task<IResult> Create(CreateCartCommand command, ISender sender)
        {
            await sender.Send(command);

            return Results.Ok();
        }

        [HttpGet]
        public async Task<IResult> Get([FromQuery] ListCartQuery query, ISender sender)
        {
            return Results.Ok(await sender.Send(new ListCartQuery(new UserId(query.UserId.Value))));
        }

        [HttpPut]
        public async Task<IResult> UpdateById([FromBody] UpdateCartRequest body, ISender sender)
        {
            var command = new UpdateCartCommand(
                new UserId(body.UserId.Value),
                new ProductId(body.ProductId.Value),
                body.Quantity);

            await sender.Send(command);

            return Results.NoContent();
        }

        [HttpDelete]
        public async Task<IResult> DeleteById([FromQuery] DeleteCartCommand request, ISender sender)
        {
            try
            {
                await sender.Send(new DeleteCartCommand(new UserId(request.UserId.Value), new ProductId(request.ProductId.Value)));

                return Results.NoContent();
            }
            catch (CartNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        }
    }
}
