using Microsoft.AspNetCore.Mvc;
using MediatR;

using Domain.PurchaseHistories;
using Application.PurchaseHistories.Create;
using Application.PurchaseHistories.Delete;
using Application.PurchaseHistories.Get;
using Application.PurchaseHistories.List;
using System.Security.Claims;
using Domain.Users;
using Microsoft.AspNetCore.Authorization;

namespace Web.API.Endpoints
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PurchaseHistoryController : ControllerBase
    {
        [HttpPost]
        public async Task<IResult> Create(CreatePurchaseHistoryRequest command, ISender sender)
        {
            string UserId = User.FindFirstValue("id")!;

            await sender.Send(new CreatePurchaseHistoryCommand(new UserId(new Guid(UserId)), command.CreatePurchaseHistoryItemRequest));

            return Results.Ok();
        }

        [HttpGet]
        public async Task<IResult> Get(ISender sender)
        {
            string UserId = User.FindFirstValue("id")!;

            return Results.Ok(await sender.Send(new ListPurchaseHistoryQuery(new UserId(new Guid(UserId)))));
        }

        [HttpGet("{id:guid}")]
        public async Task<IResult> GetById(Guid id, ISender sender)
        {
            try
            {
                string UserId = User.FindFirstValue("id")!;

                return Results.Ok(await sender.Send(new GetPurchaseHistoryQuery(new UserId(new Guid(UserId)), new PurchaseHistoryId(id))));
            }
            catch (PurchaseHistoryNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        }

        [Authorize(Roles = nameof(UserRole.Admin))]
        [HttpDelete("{id:guid}")]
        public async Task<IResult> DeleteById(Guid id, ISender sender)
        {
            try
            {
                string UserId = User.FindFirstValue("id")!;

                await sender.Send(new DeletePurchaseHistoryCommand(new UserId(new Guid(UserId)),new PurchaseHistoryId(id)));

                return Results.NoContent();
            }
            catch (PurchaseHistoryNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        }
    }
}
