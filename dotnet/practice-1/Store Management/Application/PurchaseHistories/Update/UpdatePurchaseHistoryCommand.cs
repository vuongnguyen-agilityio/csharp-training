using Domain.PurchaseHistories;
using Domain.Users;
using MediatR;

namespace Application.PurchaseHistories.Update
{
    public record UpdatePurchaseHistoryCommand(
        PurchaseHistoryId PurchaseHistoryId,
        UserId UserId,
        string Currency,
        decimal Amount) : IRequest;

    public record UpdatePurchaseHistoryRequest(
        UserId UserId,
        string Currency,
        decimal Amount);
}
