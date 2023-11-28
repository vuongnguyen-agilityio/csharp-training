using Application.Carts.Create;
using Application.Carts.Delete;
using Application.Carts.Get;
using Application.Carts.List;
using Application.Carts.Update;
using Carter;
using Domain.Carts;
using Domain.Products;
using Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Endpoints;

public class Carts : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("carts", async (CreateCartCommand command, ISender sender) =>
        {
            await sender.Send(command);

            return Results.Ok();
        });

        // FIXME: The FromBody not work in GET method. Changing to FromQuery but still got error parsing complex query object
        app.MapGet("carts", async ([FromBody] ListCartQuery query, ISender sender) =>
        {
            return Results.Ok(await sender.Send(new ListCartQuery(new UserId(query.UserId.Value))));
        });

        app.MapPut("carts", async ([FromBody] UpdateCartRequest body, ISender sender) =>
        {
            var command = new UpdateCartCommand(
                new UserId(body.UserId.Value),
                new ProductId(body.ProductId.Value),
                body.Quantity);

            await sender.Send(command);

            return Results.NoContent();
        });

        // FIXME: The FromForm not work in DELETE method
        app.MapDelete("carts", async ([FromForm] DeleteCartCommand request, ISender sender) =>
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
        });
    }
}