using Application.Products.Create;
using Carter;
using MediatR;

namespace Web.API.Endpoints;

public class Products : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("products", async (CreateProductCommand command, ISender sender) =>
        {
            await sender.Send(command);

            return Results.Ok();
        });
    }
}
