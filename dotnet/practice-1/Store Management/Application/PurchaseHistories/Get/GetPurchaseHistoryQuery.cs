using Application.Abstractions.Messaging;
using Domain.PurchaseHistories;
using Domain.PurchaseHistoryItems;
using Domain.Users;

namespace Application.PurchaseHistories.Get
{
    public record GetPurchaseHistoryQuery(UserId UserId, PurchaseHistoryId PurchaseHistoryId) : ICommand<PurchaseHistoryResponse>;

    public record PurchaseHistoryResponse(
        Guid Id,
        Guid UserId,
        string Currency,
        decimal Amount,
        List<PurchaseHistoryItem> PurchaseHistoryItems);
}
