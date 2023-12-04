using Application.PurchaseHistoryItems.Create;
using Domain.Users;
using MediatR;

namespace Application.PurchaseHistories.Create
{
    public record CreatePurchaseHistoryRequest(
        UserId UserId,
        List<CreatePurchaseHistoryItemRequest> CreatePurchaseHistoryItemRequest) : IRequest;

    public record CreatePurchaseHistoryCommand(
        UserId UserId,
        List<CreatePurchaseHistoryItemCommand> CreatePurchaseHistoryItemCommand) : IRequest;
}
