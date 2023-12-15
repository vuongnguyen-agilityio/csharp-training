using Application.Abstractions.Messaging;
using Domain.PurchaseHistories;
using Domain.Users;

namespace Application.PurchaseHistories.Update
{
    public record UpdatePurchaseHistoryCommand(
        PurchaseHistoryId PurchaseHistoryId,
        UserId UserId,
        string Currency,
        decimal Amount) : ICommand;

    public record UpdatePurchaseHistoryRequest(
        UserId UserId,
        string Currency,
        decimal Amount);
}
