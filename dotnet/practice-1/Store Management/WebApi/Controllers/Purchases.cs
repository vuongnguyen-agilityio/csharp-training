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
            string userId = User.FindFirstValue("id")!;

            await sender.Send(new CreatePurchaseHistoryCommand(new UserId(new Guid(userId)), command.CreatePurchaseHistoryItemRequest));

            return Results.Ok();
        }

        [HttpGet]
        public async Task<IResult> Get(ISender sender)
        {
            string userId = User.FindFirstValue("id")!;

            return Results.Ok(await sender.Send(new ListPurchaseHistoryQuery(new UserId(new Guid(userId)))));
        }

        [HttpGet("{id:guid}")]
        public async Task<IResult> GetById(Guid id, ISender sender)
        {
            string userId = User.FindFirstValue("id")!;

            return Results.Ok(await sender.Send(new GetPurchaseHistoryQuery(new UserId(new Guid(userId)), new PurchaseHistoryId(id))));
        }

        [Authorize(Roles = nameof(UserRole.Admin))]
        [HttpDelete("{id:guid}")]
        public async Task<IResult> DeleteById(Guid id, ISender sender)
        {
            string userId = User.FindFirstValue("id")!;

            await sender.Send(new DeletePurchaseHistoryCommand(new UserId(new Guid(userId)),new PurchaseHistoryId(id)));

            return Results.NoContent();
        }
    }
}
