using Application.Abstractions.Messaging;
using Application.PurchaseHistoryItems.Create;
using Domain.Users;

namespace Application.PurchaseHistories.Create
{
    public record CreatePurchaseHistoryRequest(
        List<CreatePurchaseHistoryItemRequest> CreatePurchaseHistoryItemRequest) : ICommand;

    public record CreatePurchaseHistoryCommand(
        UserId UserId,
        List<CreatePurchaseHistoryItemRequest> CreatePurchaseHistoryItemRequest) : ICommand;
}
