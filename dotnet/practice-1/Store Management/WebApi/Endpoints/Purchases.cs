using Application.PurchaseHistories.Create;
using Application.PurchaseHistories.Delete;
using Application.PurchaseHistories.Get;
using Application.PurchaseHistories.List;
using Carter;
using Domain.PurchaseHistories;
using MediatR;

namespace Web.API.Endpoints
{
    public class PurchaseHistories : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("purchases", async (CreatePurchaseHistoryCommand command, ISender sender) =>
            {
                await sender.Send(command);

                return Results.Ok();
            });

            app.MapGet("purchases", async (ISender sender) =>
            {
                return Results.Ok(await sender.Send(new ListPurchaseHistoryQuery()));
            });

            app.MapGet("purchases/{id:guid}", async (Guid id, ISender sender) =>
            {
                try
                {
                    return Results.Ok(await sender.Send(new GetPurchaseHistoryQuery(new PurchaseHistoryId(id))));
                }
                catch (PurchaseHistoryNotFoundException e)
                {
                    return Results.NotFound(e.Message);
                }
            });

            app.MapDelete("purchases/{id:guid}", async (Guid id, ISender sender) =>
            {
                try
                {
                    await sender.Send(new DeletePurchaseHistoryCommand(new PurchaseHistoryId(id)));

                    return Results.NoContent();
                }
                catch (PurchaseHistoryNotFoundException e)
                {
                    return Results.NotFound(e.Message);
                }
            });
        }
    }
}
