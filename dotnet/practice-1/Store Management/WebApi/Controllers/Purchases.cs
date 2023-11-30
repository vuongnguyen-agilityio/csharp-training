using Microsoft.AspNetCore.Mvc;
using MediatR;

using Domain.PurchaseHistories;
using Application.PurchaseHistories.Create;
using Application.PurchaseHistories.Delete;
using Application.PurchaseHistories.Get;
using Application.PurchaseHistories.List;

namespace Web.API.Endpoints
{
    [ApiController]
    [Route("[controller]")]
    public class PurchaseHistoryController : ControllerBase
    {
        [HttpPost]
        public async Task<IResult> Create(CreatePurchaseHistoryCommand command, ISender sender)
        {
            await sender.Send(command);

            return Results.Ok();
        }

        [HttpGet]
        public async Task<IResult> Get(ISender sender)
        {
            return Results.Ok(await sender.Send(new ListPurchaseHistoryQuery()));
        }

        [HttpGet("{id:guid}")]
        public async Task<IResult> GetById(Guid id, ISender sender)
        {
            try
            {
                return Results.Ok(await sender.Send(new GetPurchaseHistoryQuery(new PurchaseHistoryId(id))));
            }
            catch (PurchaseHistoryNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IResult> DeleteById(Guid id, ISender sender)
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
        }
    }
}
