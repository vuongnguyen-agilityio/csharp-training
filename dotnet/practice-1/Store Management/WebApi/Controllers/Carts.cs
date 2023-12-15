using Microsoft.AspNetCore.Mvc;
using MediatR;

using Domain.Products;
using Domain.Users;
using Application.Carts.Create;
using Application.Carts.Delete;
using Application.Carts.List;
using Application.Carts.Update;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Web.API.Endpoints
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase
    {
        [HttpPost]
        public async Task<IResult> Create(CreateCartRequest command, ISender sender)
        {
            string UserId = User.FindFirstValue("id")!;
            await sender.Send(new CreateCartCommand(new UserId(new Guid(UserId)), new ProductId(command.ProductId.Value), command.Quantity));

            return Results.Ok();
        }

        [HttpGet]
        public async Task<IResult> Get(ISender sender)
        {
            string UserId = User.FindFirstValue("id")!;
            return Results.Ok(await sender.Send(new ListCartQuery(new UserId(new Guid(UserId)))));
        }

        [HttpPut]
        public async Task<IResult> UpdateById([FromBody] UpdateCartRequest body, ISender sender)
        {
            string UserId = User.FindFirstValue("id")!;
            var command = new UpdateCartCommand(
                new UserId(new Guid(UserId)),
                new ProductId(body.ProductId.Value),
                body.Quantity);

            await sender.Send(command);

            return Results.NoContent();
        }

        [HttpDelete]
        public async Task<IResult> DeleteById([FromQuery] DeleteCartRequest request, ISender sender)
        {
            string UserId = User.FindFirstValue("id")!;
            await sender.Send(new DeleteCartCommand(new UserId(new Guid(UserId)), new ProductId(request.ProductId.Value)));

            return Results.NoContent();
        }
    }
}
